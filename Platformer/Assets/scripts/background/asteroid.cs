using System;
using System.Collections;
using System.Collections.Generic;using TMPro;using UnityEditor.UIElements;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float speed;
    public float border;

    public Vector3 screenReference;
    public Vector3 screenUpdate;
    public Vector3 screen;

    public Vector3 edgeleft;
    public Vector3 edgeright;
    

    // Start is called before the first frame update
    void Start()
    {
        screenReference = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        screenUpdate = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z));
        
        screen.x = (screenUpdate.x - screenReference.x);

        edgeleft.x = screen.x + screenReference.x;
        edgeright.x = screen.x - screenReference.x;
        
        
        transform.position = transform.position + new Vector3(speed,0 , 0);
        
        //Output the current screen window width in the console
        //Debug.Log("Screen Width : " + screenReference.x);
        //Debug.Log("Screen Width : " + screenUpdate.x);
        //Debug.Log("Screen Width : " + screen.x);

        if (transform.position.x < (edgeleft.x - border))
        {
            transform.position = new Vector3((edgeright.x + border), transform.position.y, transform.position.z);
        }
        

    }
}
