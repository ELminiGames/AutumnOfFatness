using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakingGauge : MonoBehaviour
{
    [SerializeField] private int gaugeMin;          //ゲージの最小値
    [SerializeField] private int gaugeMax;          //ゲージの最大値

    [SerializeField] private int lv1min;            //安眠状態の時の最小値
    [SerializeField] private int lv1max;            //最大値

    [SerializeField] private int lv2min;            //普通に寝ている時の最小値
    [SerializeField] private int lv2max;            //最大値

    [SerializeField] private int lv3min;            //ちょっと苦しいときの最小値
    [SerializeField] private int lv3max;            //最大値

    [SerializeField] private float variableVal;
    [SerializeField] private int wakingSub;

    private bool isRestful;            
    private bool isOrdinary;
    private bool isShallow;

    [SerializeField]private float wakingGauge;       //ゲージの変動値
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        isRestful = false;
        isOrdinary = false;
        isShallow = false;
        wakingGauge = 0;
        deltaTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime >= variableVal)
        {
            deltaTime = 0.0f;
            if (wakingGauge > lv1min && wakingGauge < lv1max)
            {
                //安眠
                isRestful = true;
                isOrdinary = false;
                isShallow = false;
            }
            else if (wakingGauge > lv2min && wakingGauge < lv2max)
            {   
                //普通
                isRestful = false;
                isOrdinary = true;
                isShallow = false;
            }
            else if (wakingGauge > lv3min && wakingGauge < lv3max)
            {   
                //苦眠
                isRestful = false;
                isOrdinary = false;
                isShallow = true;
            }
            else
            {
                //起床
                isRestful = false;
                isOrdinary = false;
                isShallow = false;
            }
            if(wakingGauge > 0)
            {
                Debug.Log("減少");
                wakingGauge -= wakingSub;
            }
        }
    }

    public void SetGauge(float val)
    {
        wakingGauge += val;
    }
}
