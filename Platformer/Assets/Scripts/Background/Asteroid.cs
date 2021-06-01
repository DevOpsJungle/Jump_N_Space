/*
 * Script: Asteroid
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

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
        var position = transform.position;
        position = position + new Vector3(speed*Time.deltaTime,0 , 0);

        if (position.x < ScreenBoundary.edgeleft - edgeext)
        {
            
            position = new Vector3(ScreenBoundary.edgeright, position.y, position.z);
            
        }
        
        if (position.x > ScreenBoundary.edgeright + edgeext)
        {
            position = new Vector3(ScreenBoundary.edgeleft, position.y, position.z);
        }
        
        transform.position = position;
        
        //Output the current screen window width in the console
        
        //Debug.Log("Edge Left : " + ScreenBoundary.edgeleft);
        //Debug.Log("Edge Right : " + ScreenBoundary.edgeright);
    }
}
