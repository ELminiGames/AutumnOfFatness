using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private GameObject Player;
    [SerializeField] private WakingGauge wakingGauge;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float WaitMaxTime;
    [SerializeField, Range(0, 100)] private float WarningPer;
    [SerializeField] private float WarkingAdd;
    private bool Stop = false;
    private float StopTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Stop) {
            Move();
        }
        else {
            Wait();
        }
    }

    private void Move() {
        if (!animator.GetBool("Walk")) {
            animator.SetBool("Walk", true);
        }
        rb.velocity = gameObject.transform.forward * MoveSpeed;
    }

    private void Wait() {
        StopTime -= Time.deltaTime;

        // 待ち終了処理
        if (StopTime <= 0.0f) {
            // プレイヤーのほうに向かう処理
            if (100.0f * Random.value <= WarningPer) {
                gameObject.transform.LookAt(Player.transform);
            }
            else {
                float NewAngle = 180.0f * Random.value;
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + NewAngle, gameObject.transform.eulerAngles.z);
            }
            Stop = false;
        }
    }

    public void Escape() {
        float NewAngle = 180.0f * Random.value;
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + NewAngle, gameObject.transform.eulerAngles.z);
        Stop = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Wall") {
            animator.SetBool("Walk", false);
            StopTime = WaitMaxTime * Random.value;
            Stop = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            animator.SetBool("Walk", false);
            StopTime = WaitMaxTime * Random.value;
            Stop = true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            StopTime += Time.deltaTime;
            wakingGauge.SetGauge(WarkingAdd);
        }
    }
}
