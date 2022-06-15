using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _cam;

    private float _move_speed = 30f;
    private Vector3 _jump_force = new Vector3(0.0f, 300.0f, 0.0f);
    private bool _jump = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cam = transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _rb.velocity.y == 0.0f)
            _jump = true;
        Rotations();
    }

    private void FixedUpdate()
    {
        Movement();

        if(_jump)
        {
            _jump = false;
            _rb.AddForce(_jump_force, ForceMode.Impulse);
        }
    }

    private void Rotations()
    {
        float horizontal = Input.GetAxisRaw("Mouse X");
        float vertical = Input.GetAxisRaw("Mouse Y");
        transform.rotation *= Quaternion.Euler(0.0f, horizontal, 0.0f);
        _cam.rotation *= Quaternion.Euler(vertical, 0.0f, 0.0f);
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _rb.AddForce((vertical * _move_speed) * transform.forward, ForceMode.Impulse);
        _rb.AddForce((horizontal * _move_speed) * transform.right, ForceMode.Impulse);
    }
}
