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
    public static Camera camera_player;

    private void Awake()
    {
        camera_player = GetComponent<Camera>();
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
        var player_pos = PlayerController.player_pos;
        var camera_trans = camera_player.transform;
        camera_trans.position = new Vector3(player_pos.x, player_pos.y, camera_trans.position.z);
    }
}
