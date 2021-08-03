/*
 * Script: Entity Movement
 * Author: Vincent Becker
 * Source: https://github.com/Brackeys/2D-Character-Controller
 * Last Change: 01.06.21
 * Script that handles the core aspects of the player movement
 */

using System;
using UnityEngine;
using UnityEngine.Events;

public class EntityMovement : MonoBehaviour
{
    private const float groundedradius = .2f;           /* Radius of the overlap circle to determine if grounded */
    [SerializeField] private float jumpforce = 400f;    /* SerializeField show variable in Inspector */
    [Range(0, .3f)] [SerializeField] private float movementsmoothing = .05f;
    [SerializeField] private bool aircontrol;
    [SerializeField] private LayerMask whatisground;
    [SerializeField] private Transform groundcheck;

    [Header("Events")] /* Structured view in the Inspector */ [Space]
    public UnityEvent OnLandEvent;

    private bool facingright = true; /* for determining which way the player is currently facing */
    private bool grounded;
    private Rigidbody2D v_rigidbody2D;
    private Vector3 velocity = Vector3.zero;


    //Awake is called when the script is being loaded
    private void Awake()
    {
        groundcheck = GameObject.Find("Groundcheck").GetComponent<Transform>();
        v_rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    //used for physics calculations, FixedUpdate gets called 50 times per second regardless of Fps
    private void FixedUpdate()
    {
        var wasgrounded = grounded;
        grounded = false;

        /* The entity is grounded if a circlecast to the groundcheck position hits anything designated as ground */
        var colliders = Physics2D.OverlapCircleAll(groundcheck.position, groundedradius, whatisground);
        for (var i = 0; i < colliders.Length; i++)
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasgrounded)
                    OnLandEvent.Invoke();
            }
    }

    public void Move(float move, bool jump)
    {
        if (grounded || aircontrol)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, v_rigidbody2D.velocity.y);
            /* Smooth and apply the velocity to the entity */
            v_rigidbody2D.velocity =
                Vector3.SmoothDamp(v_rigidbody2D.velocity, targetVelocity, ref velocity, movementsmoothing);

            if (move > 0 && !facingright)
                Flip();
            else if (move < 0 && facingright) Flip();
        }

        if (grounded && jump)
        {
            grounded = false;
            v_rigidbody2D.AddForce(new Vector2(0f, jumpforce));
        }
    }

    private void Flip()
    {
        /* Switch the way the entity is labelled as facing */
        facingright = !facingright;

        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    [Serializable] public class BoolEvent : UnityEvent<bool>
    {
    }
}