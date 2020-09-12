using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CdioCs;

public class IOData : MonoBehaviour
{
    private Cdio _cdio;
    private short _id;
    int res;
    public bool StopAlarm = false;
    public byte WakingLevel;

    [SerializeField] private GameObject[] _obj;

    void Start() {
        _cdio = new Cdio();

        //                      シリアル名
        res = _cdio.Init("DIO000", out _id);
    }

    void Update() {
        if (res == (int)CdioConst.DIO_ERR_SUCCESS) {
            InputData();
        }
    }

    public void SetWakingLevel(int val) {
        WakingLevel = (byte)val;
        OutputData();
    }


    private void InputData() {
        var data = new byte[1];
        var bitNo = new short[] { 0 };
        _cdio.InpMultiBit(_id, bitNo, 1, data);

        if (data[0] == 1) {
            StopAlarm = true;
        }
    }

    private void OutputData() {
        var data = new byte[] { WakingLevel };
        var bitNo = new short[] { 0 };
        _cdio.OutMultiBit(_id, bitNo, 1, data);
    }

    private void OnDestroy() {
        _cdio.Exit(_id);
    }
}
