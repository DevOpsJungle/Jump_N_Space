using System;
using System.Collections;
using System.Collections.Generic;using UnityEditor.UIElements;
using UnityEngine;




public class asteroid : MonoBehaviour
{
    public float speed;
    public float border;

    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z));
        
        transform.position = transform.position + new Vector3(speed,0 , 0);

        if (transform.position.x < (screenBounds.x - border))
        {
            transform.position = new Vector3(-screenBounds.x + border, transform.position.y, transform.position.z);
        }
        

    }
}
