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
    [SerializeField] private Camera cam;
    private static Vector3 camera_pos;  //screenpos => x, y - middle of every Viewport Axis to Worldspace

    private void Awake()
    {
        cam = GameObject.Find("CameraPlayer").GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
        GetCameraPos();
    }

    // LateUpdate is called after Update
    void Update()
    {
        SetCamera();
        GetCameraPos();
    }

    private void SetCamera()
    {
        var player_pos = PlayerController.GetPlayerPos();
        var camera_pos = cam.transform;
        camera_pos.position = new Vector3(player_pos.x, player_pos.y, camera_pos.position.z);
    }


    private void GetCameraPos()
    {
        camera_pos = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, - cam.transform.position.z));
    }


    public static Camera GetCamera() /*When using GetCamera() in Update you have to use LateUpdate() else you will get the Camera properties of the Last Frame.*/ 
    {
        return Camera.main;
    }
    
    public static Vector3 GetScreenPos()
    {
        return camera_pos;
    }
}
