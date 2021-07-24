/*
 * Script: Asteroid
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private List <Transform> asteroid_list;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaceAsteroid(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceAsteroid()
    {
        Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
        Instantiate(chosen_asteroid, Vector3Random(), Quaternion.identity, transform);
    }

    private Vector3 Vector3Random()
    {
        float w = Random.Range(-ScreenViewport.width/2, ScreenViewport.width/2);
        float h = Random.Range(-ScreenViewport.height/2, ScreenViewport.height/2); 
        
        Vector3 rand = new Vector3(w, h, 0);
        Vector3 center = ScreenViewport.GetScreenPos();
        Vector3 f = center + rand;
        Debug.Log(rand);
        Debug.Log(center);
        
        Debug.Log(f);
        return f;
    }
    
}
