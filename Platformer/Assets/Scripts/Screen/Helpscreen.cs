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
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Helpscreen : MonoBehaviour
{
    private new Transform transform;
    [SerializeField] private Camera cam;
    public static Vector3 screenpos;
    
    private void Awake()
    {
        transform = GetComponent<Transform>();
        cam = CameraView.GetCamera();
        
        
        
        SetHelpscreenPos();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after Update
    void Update()
    {
        SetHelpscreenPos();
        Debug.Log(screenpos);
        transform.position = screenpos;
    }

    private void SetHelpscreenPos()
    {
        screenpos = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -cam.transform.position.z));
    }
}