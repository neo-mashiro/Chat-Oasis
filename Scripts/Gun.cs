using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    private void Update() {
        // Input.GetMouseButtonDown(0) for single-shot firearms
        if (Input.GetMouseButton(0)) {
            GameObject bullet = ObjectPool.SharedPool.Fetch();
            if (bullet) {
                bullet.transform.position = transform.position + transform.up;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().velocity = transform.up * 10;
            }
        }
    }
}
