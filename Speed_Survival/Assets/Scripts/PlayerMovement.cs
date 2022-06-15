using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private float _move_speed = 30f;
    private Vector3 _jump_force = new Vector3(0.0f, 300.0f, 0.0f);
    private bool _jump = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _rb.velocity.y <= 0.0f)
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
        transform.rotation *= Quaternion.Euler(vertical, horizontal, 0.0f);
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(_move_speed * transform.forward, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(_move_speed * -transform.forward, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(_move_speed * transform.right, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(_move_speed * -transform.right, ForceMode.Impulse);
        }
    }
}
