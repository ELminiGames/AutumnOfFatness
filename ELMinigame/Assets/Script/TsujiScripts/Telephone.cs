using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;
    [SerializeField] private GameObject telephoneObj;

    [SerializeField] private float deltaTime;
    private bool isBell;

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
        if (deltaTime >= interval)
        {
            deltaTime = 0.0f;
            if (isBell)
            {
                InitTelephone();
                isBell = false;
            }
            else
            {
                isBell = true;
            }
        }
        if (isBell)
        {
            VibreateTelephone();
            wakingGauge.SetGauge(0.1f);   //起床ゲージ上昇
        }
    }

    private void InitTelephone()
    {
        telephoneObj.GetComponent<Transform>().localRotation = Quaternion.identity;
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
