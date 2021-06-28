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
    private new static Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        SetCamera();
    }

    private void SetCamera()
    {
        var player_pos = PlayerController.GetPlayerPos();
        var camera_pos = camera.transform;
        camera_pos.position = new Vector3(player_pos.x, player_pos.y, camera_pos.position.z);
    }

    public static Camera GetCamera() /*When using GetCamera() in Update you have to use LateUpdate() else you will get the Camera properties of the Last Frame.*/ 
    {
        return Camera.main;
    }
}
