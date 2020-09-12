using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirCon : MonoBehaviour
{
    [SerializeField] private int roomTemp;           //室温    
    [SerializeField] private int setupTemp;          //設定温度
    [SerializeField] private int basicSpeed;         //基本速度(温度が下がる速度)
    [SerializeField] private int variableVal;        //変動値

    [SerializeField] private int AbsVal;             //絶対値
    [SerializeField] private float deltaTime;
    [SerializeField] private float wakingUpVal;

    [SerializeField] private TextMesh setupTempTextMesh;
    [SerializeField] private Text     roomTempText;
    [SerializeField] private AudioClip SE01;

    private AudioSource audio;
    private GameObject scriptObj;
    private WakingGauge wakingGauge;

    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0.0f;
        if(basicSpeed == 0)
        {
            basicSpeed = 100;
        }
        AbsVal = Mathf.Abs(setupTemp - roomTemp);
        variableVal = basicSpeed / AbsVal;

        scriptObj = GameObject.Find("WakingGauge");
        wakingGauge = scriptObj.GetComponent<WakingGauge>();

        setupTempTextMesh.text = setupTemp.ToString();
        roomTempText.text = roomTemp.ToString();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetUpTempAdjustment();
        deltaTime += Time.deltaTime;
        if(deltaTime >= variableVal)
        {
            deltaTime = 0.0f;
            RoomTempChange();
            wakingGauge.SetGauge(wakingUpVal);
        }

        if (!audio.isPlaying)
        {
            audio.PlayOneShot(SE01);
        }
    }

    void RoomTempChange()
    {
        if(roomTemp != setupTemp)
        {
            AbsVal = roomTemp - setupTemp;
            if (AbsVal < 0)
            {
                roomTemp++;
                roomTempText.text = roomTemp.ToString();
            }
            else
            {
                roomTemp--;
                roomTempText.text = roomTemp.ToString();
            }
            AbsVal = Mathf.Abs(AbsVal);   //絶対値計算
        }
        variableVal = basicSpeed / AbsVal;               //絶対値で温度が変化する基本速度を割る(温度の変動値を計算)
    }

    void SetUpTempAdjustment()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            setupTemp++;
            setupTempTextMesh.text = setupTemp.ToString();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            setupTemp--;
            setupTempTextMesh.text = setupTemp.ToString();
        }
    }

    int GetRoomTemp()
    {
        return roomTemp;
    }
}
