/*
 * Script: Planet
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(ScreenViewport.screenpos.x,0,0) + pos;
    }
}
