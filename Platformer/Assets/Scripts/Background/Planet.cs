/*
 * Script: Planet
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Planet : MonoBehaviour
{
    [SerializeField] private Transform planet;
    private Transform cam_trans;
    private Vector3 last_cam_pos;

    [SerializeField] private float parallax;
    [SerializeField] private Vector3 start_pos;

    private void Awake()
    {
        Instantiate(planet, new Vector3(0, 0, 0), Quaternion.identity, transform);
        cam_trans = CameraView.GetCamera().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        last_cam_pos = cam_trans.position - start_pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 delta_move = cam_trans.position - last_cam_pos;
        
        transform.position += (delta_move * parallax);
        last_cam_pos = cam_trans.position;
    }
}
