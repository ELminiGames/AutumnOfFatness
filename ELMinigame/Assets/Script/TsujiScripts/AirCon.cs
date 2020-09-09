using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCon : MonoBehaviour
{
    [SerializeField] private int roomTemp;           //室温    
    [SerializeField] private int setupTemp;          //設定温度
    [SerializeField] private int basicSpeed;         //基本速度(温度が下がる速度)
    [SerializeField] private int variableVal;        //変動値

    [SerializeField] private int AbsVal;             //絶対値
    [SerializeField] private float deltaTime;

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
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime >= variableVal)
        {
            deltaTime = 0.0f;
            TempChange();
            wakingGauge.SetGauge(0.01f);    
        }
    }

    void TempChange()
    {
        if(roomTemp != setupTemp)
        {
            AbsVal = roomTemp - setupTemp;
            if (AbsVal < 0)
            {
                roomTemp++;
            }
            else
            {
                roomTemp--;
            }
            AbsVal = Mathf.Abs(AbsVal);   //絶対値計算
        }
        variableVal = basicSpeed / AbsVal;               //絶対値で温度が変化する基本速度を割る(温度の変動値を計算)
    }

    int GetRoomTemp()
    {
        return roomTemp;
    }
}
