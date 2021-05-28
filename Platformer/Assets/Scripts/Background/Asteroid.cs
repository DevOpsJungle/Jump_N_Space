using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float edgeext;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed*Time.deltaTime,0 , 0);

        if (transform.position.x < ScreenBoundary.edgeleft - edgeext)
        {
            transform.position = new Vector3(ScreenBoundary.edgeright, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > ScreenBoundary.edgeright + edgeext)
        {
            transform.position = new Vector3(ScreenBoundary.edgeleft, transform.position.y, transform.position.z);
        }
        
        //Output the current screen window width in the console
        
        //Debug.Log("Edge Left : " + ScreenBoundary.edgeleft);
        //Debug.Log("Edge Right : " + ScreenBoundary.edgeright);
    }
}
