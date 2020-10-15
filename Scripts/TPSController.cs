using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour {
    [SerializeField] private Transform attachCamera;
    [SerializeField] private float speed = 6.0f;

    private CharacterController _controller;

    private float _angle;
    private const float TurnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    private void Start() {
        _controller = GetComponent<CharacterController>();
    }

    private void Update() {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(h, 0, v);

        if (direction.magnitude >= 0.1f) {
            _angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + attachCamera.eulerAngles.y;
            direction = Quaternion.Euler(0, _angle, 0) * Vector3.forward;

            _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _angle,
                ref _turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0, _angle, 0);

            // always make sure that the move vector is normalized
            _controller.Move(direction.normalized * (speed * Time.deltaTime));
        }
    }
}
