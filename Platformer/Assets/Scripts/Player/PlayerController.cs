/*
 * Script: Player Controller
 * Author: Vincent Becker
 * Last Change: 30.05.21
 * ...I am a description...
 */

using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityMovement controller;
    
    private static Vector3 pos;
    public float runspeed = 40f;
    float horizontalmove = 0f;
    bool jump = false;

    private void Awake()
    {
        controller = GetComponent<EntityMovement>();
        pos = GetComponent<Transform>().position;
    }
    
    void Update()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, jump); 
        jump = false;

        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }

    private void FixedUpdate()
    {
        pos = GetComponent<Transform>().position;
    }

    public static Vector3 GetPlayerPos()
    {
        return pos;
    }
}