/*
 * Script: Planet
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Planet : MonoBehaviour
{
    [SerializeField] private Vector3 start_pos;
    [SerializeField] private Vector3 screen_pos;
    public bool x;
    public bool y;

    // Start is called before the first frame update
    void Start()
    {
        screen_pos = ScreenViewport.screenpos;
        transform.position = screen_pos;
    }

    // Update is called once per frame
    void Update()
    {
        SetTransformDirectiom(x,y);
    }

    void SetTransformDirectiom(bool x, bool y)
    {
        screen_pos = ScreenViewport.screenpos;
        if (x == true && y == true)
        {
            transform.position = screen_pos + start_pos;
        }
        else if (x == true)
        {
            transform.position = new Vector3(screen_pos.x, 0 , 0) + start_pos;
        }
        else if (y == true)
        {
            transform.position = new Vector3(0, screen_pos.y , 0) + start_pos;
        }
        else
        {
            transform.position = start_pos;
        }
    }
}
