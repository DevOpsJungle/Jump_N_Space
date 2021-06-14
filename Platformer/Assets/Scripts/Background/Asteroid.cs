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
using Random = System.Random;


public class Asteroid : MonoBehaviour
{
    public float speed;
    public float border;

    public Vector3 pos;
    public Vector3 start_pos;

    public int a;
    public int b;

    private void Awake()
    {
        speed = UnityEngine.Random.Range(-5, 5);
        border = UnityEngine.Random.Range(0, 16);
    }

    // Start is called before the first frame update
    void Start()
    {
        a = Mathf.RoundToInt(ScreenViewport.width);
        b = Mathf.RoundToInt(ScreenViewport.height);
        
        start_pos = new Vector3(UnityEngine.Random.Range(0, a), UnityEngine.Random.Range(0, b), 0);
        
        pos = GetComponent<Transform>().position + start_pos;
        transform.position = start_pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = GetComponent<Transform>().position + start_pos;
        
        var trans_pos = transform.position;
        trans_pos = trans_pos + new Vector3(speed*Time.fixedDeltaTime,0 , 0);
        
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
    }
}
