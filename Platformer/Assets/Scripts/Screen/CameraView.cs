/*
 * Script: Camera View
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public new Transform transform;    //player Object
    public new Camera camera;

    public static Vector3 player_pos;   //for other Classes

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var cam_Tansform = camera.transform;    //camera 
        player_pos = transform.position;   //player
        
        
        cam_Tansform.position = new Vector3(player_pos.x, player_pos.y, cam_Tansform.position.z);
        
    }
    
    
}
