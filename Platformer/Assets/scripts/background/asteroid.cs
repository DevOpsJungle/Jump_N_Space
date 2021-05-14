using System;
using System.Collections;
using System.Collections.Generic;using TMPro;using UnityEditor.UIElements;
using UnityEngine;

public class asteroid : screenspace
{
    public float speed;
    public float border;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed*Time.deltaTime,0 , 0);
        
        //Output the current screen window width in the console
        //Debug.Log("Screen Width : " + screenref.x);
        //Debug.Log("Screen Width : " + screenupd.x);
        Debug.Log("Screen Width : " + screen.x);

        if (transform.position.x < (edgeleft.x - border))
        {
            transform.position = new Vector3((edgeright.x + border), transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > (edgeright.x + border))
        {
            transform.position = new Vector3((edgeleft.x - border), transform.position.y, transform.position.z);
        }
        

    }
}
