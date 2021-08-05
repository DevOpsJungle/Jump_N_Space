/*
 * Script: PlayerController
 * Author: Vincent Becker
 * Last Change: 26.07.21
 * Extension of EntityMovement, Control of player movement
 */


using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public EntityMovement controller;
    
        private static Vector3 pos;
        public float runspeed = 40f;
        private float horizontalmove = 0f;
        private bool jump = false;

        private void Awake()
        {
            controller = GetComponent<EntityMovement>();
            pos = GetComponent<Transform>().position;
        }
    
        private void Update()
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
}