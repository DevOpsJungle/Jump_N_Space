/*
 * Script: Moving Platform
 * Author: Vincent Becker
 * Source: https://answers.unity.com/questions/1784956/how-to-move-platform-up-and-down-even-if-player-st.html
 * Last Change: 25.07.21
 * The script integrates moving platforms into the chunks
 */


using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform targetA, targetB; 
    [Range(0, .1f)] [SerializeField] private float speed;
    private bool switching = false;
    
    private void FixedUpdate()
    {
        if (!switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetA.position, speed); 
        }
        else if (switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetB.position, speed); 
        }
        if (transform.position == targetA.position)
        {
            switching = true;
        }
        else if (transform.position == targetB.position)
        {
            switching = false;
        }
    } 
}

