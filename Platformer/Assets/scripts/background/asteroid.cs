using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
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
        var trans = transform;
        trans.position = trans.position + new Vector3(speed*Time.deltaTime,0 , 0);
        
        //Output the current screen window width in the console
        //Debug.Log("Screen Width : " + screenref.x);
        //Debug.Log("Screen Width : " + screenupd.x);
        //Debug.Log("Screen Width : " + screen.x);
/*
        if (trans.position.x < (ScreenSpace.edge_left.x - border))
        {
            trans.position = new Vector3((ScreenSpace.edge_right.x + border), transform.position.y, trans.position.z);
        }
        
        if (trans.position.x > (ScreenSpace.edge_right.x + border))
        {
            trans.position = new Vector3((ScreenSpace.edge_left.x - border), transform.position.y, trans.position.z);
        }
        */

    }
}
