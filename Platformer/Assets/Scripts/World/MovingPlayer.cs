/*
 * Script: Moving Player
 * Author: Vincent Becker
 * Last Change: 01.08.21
 * The script sets the player as a child of the moving platform so that the platform can move horizontally
 */


using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField] 
    private Vector3 velocity;
    private bool moving;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
            
    }
    void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}
