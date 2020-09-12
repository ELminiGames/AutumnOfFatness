using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;
    [SerializeField] private float wakingUpVal;

    [SerializeField] private float deltaTime;
    [SerializeField] private AudioClip SE02;

    private AudioSource audio;
    private bool  isBell;
    private GameObject scriptObj;
    private GameObject serialObj;
    private WakingGauge wakingGauge;
    private SerialHandler serial;
    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0.0f;
        isBell = false;
        if (interval <= 0.0f)
        {
            interval = 2.5f;
        }
        scriptObj = GameObject.Find("WakingGauge");
        serialObj = GameObject.Find("IOData");
        wakingGauge = scriptObj.GetComponent<WakingGauge>();
        serial = serialObj.GetComponent<SerialHandler>();

        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime >= interval)
        {
            deltaTime = 0.0f;
            if (isBell)
            {
                InitAlarmClock();
                isBell = false;
            }
            else
            {
                audio.PlayOneShot(SE02);
                isBell = true;
            }
        }
        if (isBell)
        {
            VibreateAlarmClock();
            wakingGauge.SetGauge(wakingUpVal);   //起床ゲージ上昇
        }

        if (serial.GetStopAlarm())
        {
            isBell = false;
            InitAlarmClock();
            serial.SetStopAlarm(false);
        }
    }

    private void InitAlarmClock()
    {
        GetComponent<Transform>().localRotation = Quaternion.identity;
        audio.Stop();
    }

    private void VibreateAlarmClock()
    {
        float val1 = Random.Range(-RandomValue, RandomValue);
        Quaternion quaternion = GetComponent<Transform>().localRotation;
        quaternion.z = val1;
        GetComponent<Transform>().localRotation = quaternion;
    }

    public bool GetBellFlag()
    {
        return isBell;
    }

    public void SetBellFlag(bool flag)
    {
        isBell = flag;
    }
}
