/*
 * Script: Camera View
 * Author: Felix Schneider
 * Last Change: 10.06.21
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public new Transform transform;    //player Object
    public static Camera camera_player;

    public static Vector3 player_trans_pos;   //for other Classes


    private void Awake()
    {
        camera_player = gameObject.GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics update 50 Hz
    void FixedUpdate()
    {
        var camera_trans = camera_player.transform;    //camera 
        player_trans_pos = transform.position;   //player
        
        camera_trans.position = new Vector3(player_trans_pos.x, player_trans_pos.y, camera_trans.position.z);
    }
}
