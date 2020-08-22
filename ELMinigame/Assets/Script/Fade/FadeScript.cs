using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    private RectTransform rc;
    [SerializeField] private float speed = 0.01f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    public bool EndFade = false;

    void Start() {
        rc = GetComponent<RectTransform>();
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (fadeIn || fadeOut) {
            if (fadeIn) {
                rc.sizeDelta = new Vector2(rc.sizeDelta.x + speed * 16.0f, rc.sizeDelta.y + speed * 9.0f);
                if(rc.sizeDelta.x >= 1600.0f) {
                    fadeIn = false;
                    EndFade = true;
                }
            }
            else {
                rc.sizeDelta = new Vector2(rc.sizeDelta.x - speed * 16.0f, rc.sizeDelta.y - speed * 9.0f);
                if (rc.sizeDelta.x <= 0.0f) {
                    fadeOut = false;
                    EndFade = true;
                }
            }
        }
    }

    public void FadeIn() {
        fadeIn = true;
        EndFade = false;
    }

    public void FadeOut() {
        fadeOut = true;
        EndFade = false;
    }
}
