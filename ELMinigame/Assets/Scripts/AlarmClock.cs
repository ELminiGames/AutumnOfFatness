using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float velocity;          //振動の感覚
    [SerializeField] private GameObject clockObj;
    
    private bool  isBell;
    // Start is called before the first frame update
    void Start()
    {
        isBell = false;
        if (interval <= 0.0f)
        {
            interval = 2.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (isBell)
        //{
            VibreateAlarmClock();
        //}
    }

    private void VibreateAlarmClock()
    {
        float val1 = Random.Range(velocity -0.1f, velocity + 0.1f);
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
