using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = _rb.transform.forward;
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            _rb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = -_rb.transform.forward;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            _rb.velocity = Vector3.zero;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _rb.angularVelocity = Vector3.down;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _rb.angularVelocity = Vector3.up;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            _rb.angularVelocity = Vector3.zero;
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }
}
