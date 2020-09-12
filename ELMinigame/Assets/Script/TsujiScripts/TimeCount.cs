using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private int initTime;
    [SerializeField] private Text time;
    [SerializeField] private Text mini;

    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        if (initTime < 10) time.text = "0" + initTime.ToString();
        else time.text = initTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        int val = (int)deltaTime;
        if (val < 10) mini.text = "0" + val.ToString();
        else mini.text = val.ToString();
        if (val >= 60)
        {
            deltaTime = 0.0f;
            mini.text = "00";
            initTime++;
            if (val < 10) time.text = "0" + initTime.ToString();
            else time.text = val.ToString();

            if (initTime < 24) time.text = initTime.ToString();
            else
            {
                initTime = 0;
                time.text = "0" + initTime;
            }
        }
    }
}
