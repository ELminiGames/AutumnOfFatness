using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    [SerializeField] private float interval;        //振動している時間
    [SerializeField] private float RandomValue;
    [SerializeField] private float wakingUpVal;

    [SerializeField] private float deltaTime;
    [SerializeField] private AudioClip SE03;

    private AudioSource audio;
    private GameObject scriptObj;
    private WakingGauge wakingGauge;
    private bool isBell;
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

        audio = GetComponent<AudioSource>();
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
                audio.PlayOneShot(SE03);
            }
        }
        if (isBell)
        {
            VibreateTelephone();
            wakingGauge.SetGauge(wakingUpVal);   //起床ゲージ上昇
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            isBell = false;
            InitTelephone();
        }
    }

    private void InitTelephone()
    {
        GetComponent<Transform>().localRotation = Quaternion.identity;
        audio.Stop();
    }

    private void VibreateTelephone()
    {
        float val1 = Random.Range(-RandomValue , RandomValue);
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
