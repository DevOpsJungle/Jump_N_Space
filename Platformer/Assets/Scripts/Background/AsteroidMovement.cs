/*
 * Script: AsteroidMovement
 * Author: Felix Schneider
 * Last Change: 02.08.21
 * Handles the asteroid movement and animation changes dependent on direction and velocity
 */

using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour
{
    private Animator animatior;
    private float anim_rotation_factor = 5f;
    
    private float velocity;
    private float max_velocity = 2.5f;
    
    private Vector3 pos;

    private void Awake()
    {
        animatior = gameObject.GetComponent<Animator>();
        pos = gameObject.GetComponent<Transform>().position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        velocity = Random.Range(-max_velocity, max_velocity);
        
        if (velocity > 0)
        {
            animatior.speed = velocity * anim_rotation_factor;      /* speed of the animation depends on the velocity with which the asteroid moves regulated*/
            animatior.SetFloat("rotation", -1);         /* "rotation" is a parameter created in the Unity AnimationController and used under speed as a multiplier to change the rotation based on direction*/ 
        }
        else
        {
            animatior.speed = velocity * -anim_rotation_factor;
            animatior.SetFloat("rotation", 1);
        }
    }
    
    
    // Update is called once per frame
    private void Update()
    {
        transform.position = transform.position + new Vector3(velocity * Time.fixedDeltaTime, 0, 0); 
        
    }
}