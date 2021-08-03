/*
 * Script: Player Movement
 * Author: Felix Schneider
 * Last Change: 20.05.21
 * Not used anymore
 */


using UnityEngine;

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

    // Update is called once per frame
    private void FixedUpdate()
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
