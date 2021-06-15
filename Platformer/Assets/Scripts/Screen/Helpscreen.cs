/*
 * Script: Help Screen
 * Author: Johannes Wilhelm
 * Last Change: 15.06.2021
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpscreen : MonoBehaviour
{

    private Transform transform;
    public Camera helpcam;
    private static Vector3 pos;
    private void Awake()
    {
        transform = GetComponent<Transform>();
        //helpcam = CameraView.GetCamera();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetHelpscreenPos();
    }

    // LateUpdate is called after Update
    void FixedUpdate()
    {
        SetHelpscreenPos();
        Debug.Log(pos);
        transform.position = pos;
    }

    private void SetHelpscreenPos()
    {
        pos = helpcam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -helpcam.transform.position.z));
    }
}