using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private AudioClip SE;
    [SerializeField] private List<GameObject> FalseObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ShowResult(string EndTime) {
        foreach(GameObject obj in FalseObj) {
            obj.SetActive(false);
        }

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GameObject ResultTime = gameObject.transform.GetChild(1).gameObject;
        ResultTime.GetComponent<Text>().text = EndTime;
        gameObject.GetComponent<AudioSource>().PlayOneShot(SE);
        StopCorutine();
    }

    void StopCorutine()
    {
        for(int i = 0; i < 10000000;i++)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                break;
            }
        }
    }
}
