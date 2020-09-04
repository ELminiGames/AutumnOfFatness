using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;
    [SerializeField] private GameObject clockObj;

    [SerializeField] private float deltaTime;
    private bool  isBell;
    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0.0f;
        isBell = false;
        if (interval <= 0.0f)
        {
            interval = 2.5f;
        }
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
        }
    }

    private void InitAlarmClock()
    {
        clockObj.GetComponent<Transform>().localRotation = Quaternion.identity;
    }

    private void VibreateAlarmClock()
    {
        float val1 = Random.Range(-RandomValue, RandomValue);
        Quaternion quaternion = clockObj.GetComponent<Transform>().localRotation;
        quaternion.z = val1;
        clockObj.GetComponent<Transform>().localRotation = quaternion;
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
