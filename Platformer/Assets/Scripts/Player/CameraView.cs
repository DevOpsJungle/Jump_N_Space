using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraView : MonoBehaviour
{
    public Transform player;                            //player Object
    public float speed = 0.125f;
    public Camera cam;

    public static Vector3 player_worldspace_pos;        //for other Classes
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var camTransform = cam.transform;               //camera 
        var pos = player.position;                //player
        
        player_worldspace_pos = pos; 
        
        camTransform.position = new Vector3(pos.x, pos.y, camTransform.position.z);
        
    }
    
}
