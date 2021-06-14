/*
 * Script: Player Controller
 * Author: Vincent Becker
 * Last Change: 30.05.21
 * ...I am a description...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public EntityMovement controller;
    public static Vector3 player_pos;

    public float runspeed = 40f;

    float horizontalmove = 0f;
    bool jump = false;

    private void Awake()
    {
        controller = GetComponent<EntityMovement>();
        player_pos = GetComponent<Transform>().position;
    }
    
    void Update()
    {
        player_pos = GetComponent<Transform>().position;
        
        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}