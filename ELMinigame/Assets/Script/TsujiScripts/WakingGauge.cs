using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private int   wakingSub;
    [SerializeField] private Text  time1;
    [SerializeField] private Text  time2;
    [SerializeField] private Text  time3;

    private int outputVal;

    [SerializeField]private float wakingGauge;       //ゲージの変動値
    private float deltaTime;

    private Result script;
    private GameObject resultObj;
    // Start is called before the first frame update
    void Start()
    {
        wakingGauge = 0;
        deltaTime = 0.0f;

        resultObj = GameObject.Find("Result");
        script = resultObj.GetComponent<Result>();
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
                outputVal = 0;
            }
            else if (wakingGauge > lv2min && wakingGauge < lv2max)
            {   
                //普通
                outputVal = 1; 
            }
            else if (wakingGauge > lv3min && wakingGauge < lv3max)
            {   
                //苦眠
                outputVal = 2;
            }
            else
            {
                //起床
                outputVal = 3;
                script.ShowResult(time1.text+time2.text+time3.text);
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

    public int OutputWaikngVal()
    {
        return outputVal;
    }
}
