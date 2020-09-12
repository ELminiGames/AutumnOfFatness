﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;

    [SerializeField] private float deltaTime;
    private bool  isBell;

    private GameObject scriptObj;
    private WakingGauge wakingGauge;
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
        wakingGauge = scriptObj.GetComponent<WakingGauge>();
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
                isBell = true;
            }
        }
        if (isBell)
        {
            VibreateAlarmClock();
            wakingGauge.SetGauge(0.1f);   //起床ゲージ上昇
        }
    }

    private void InitAlarmClock()
    {
        GetComponent<Transform>().localRotation = Quaternion.identity;
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
