using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;
    [SerializeField] private GameObject telephoneObj;

    private bool isBell;
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
        VibreateTelephone();
        //}
    }

    private void VibreateTelephone()
    {
        float val1 = Random.Range(-RandomValue , RandomValue);
        Quaternion quaternion = telephoneObj.GetComponent<Transform>().localRotation;
        quaternion.z = val1;
        telephoneObj.GetComponent<Transform>().localRotation = quaternion;
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
