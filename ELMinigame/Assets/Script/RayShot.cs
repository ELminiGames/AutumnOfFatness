using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShot : MonoBehaviour
{
    [SerializeField] private GameObject hit_target;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 1000f;

            bool is_hit = Physics.Raycast(ray, out hit_info, max_distance);

            if (is_hit) {
                if (hit_info.transform.name == hit_target.name) {
                    hit_target.GetComponent<MoveCat>().Escape();
                }
            }
        }
    }
}
