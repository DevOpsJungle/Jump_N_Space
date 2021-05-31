/*
 * Script: Entity Movement
 * Author: Vincent Becker
 * Source: https://github.com/Brackeys/2D-Character-Controller
 * Last Change: 30.05.21
 * ...I am a description...
 */

using UnityEngine;
using UnityEngine.Events;

public class EntityMovement : MonoBehaviour
{
	[SerializeField] private float jumpforce = 400f; // SerializeField show variable up in Inspector							
	[Range(0, .3f)] [SerializeField] private float movementsmoothing = .05f;	
	[SerializeField] private bool aircontrol = false;							
	[SerializeField] private LayerMask whatisground;							
	[SerializeField] private Transform groundcheck;							

	const float groundedradius = .2f; // Radius of the overlap circle to determine if grounded
	private bool grounded;
	private Rigidbody2D v_rigidbody2D;
	private bool facingright = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;

	[Header("Events")] // Structured view in the Inspector
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
	
	private void Awake() {
		v_rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate() {
		bool wasgrounded = grounded;
		grounded = false;

		// The entity is grounded if a circlecast to the groundcheck position hits anything designated as ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheck.position, groundedradius, whatisground);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				grounded = true;
				if (!wasgrounded)
					OnLandEvent.Invoke();
			}
		}
	}
	
	public void Move(float move, bool jump) {

		if (grounded || aircontrol) {

			Vector3 targetVelocity = new Vector2(move * 10f, v_rigidbody2D.velocity.y);
			// Smooth and apply the velocity to the entity
			v_rigidbody2D.velocity = Vector3.SmoothDamp(v_rigidbody2D.velocity, targetVelocity, ref velocity, movementsmoothing);
			
			if (move > 0 && !facingright) {
				Flip();
			}
			else if (move < 0 && facingright) {
				Flip();
			}
		}
		if (grounded && jump) {
			grounded = false;
			v_rigidbody2D.AddForce(new Vector2(0f, jumpforce));
		}
	}
	
	private void Flip() {
		// Switch the way the entity is labelled as facing.
		facingright = !facingright;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
