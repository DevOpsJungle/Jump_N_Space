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
    public float border;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var trans_pos = transform.position;
        trans_pos = trans_pos + new Vector3(speed*Time.deltaTime,0 , 0);
        
        //left side
        if (trans_pos.x < ScreenViewport.edgeleft - border)
        {
            trans_pos = new Vector3(ScreenViewport.edgeright + border, trans_pos.y, trans_pos.z);
        }
        
        //right side
        if (trans_pos.x > ScreenViewport.edgeright + border)
        {
            trans_pos = new Vector3(ScreenViewport.edgeleft - border, trans_pos.y, trans_pos.z);
        }
        
        transform.position = trans_pos;
        
        //Output the current screen window width in the console
        
        //Debug.Log("Edge Left : " + ScreenBoundary.edgeleft);
        //Debug.Log("Edge Right : " + ScreenBoundary.edgeright);
    }
}
