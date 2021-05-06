using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_movement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Transform transform;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
