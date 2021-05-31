using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public new Transform transform;
    public float force;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.up * force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(transform.up * -force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.right * -force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.right * force);
        }
    }
}
