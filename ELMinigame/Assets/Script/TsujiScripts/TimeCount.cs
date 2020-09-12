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
        time.text = "0" + initTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        int val = (int)deltaTime;
        mini.text = val.ToString();
    }
}
