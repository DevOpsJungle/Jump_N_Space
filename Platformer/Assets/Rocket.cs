using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rocket : MonoBehaviour
{
    Vector3 vector;
    float movingspeed = 100.0f;
    Rigidbody r_rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector3(-1.0f, 1.0f, 0.0f);
        r_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        r_rigidbody.velocity = vector * movingspeed;

    }
}
