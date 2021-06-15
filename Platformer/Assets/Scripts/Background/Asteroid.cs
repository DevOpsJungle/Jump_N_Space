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

    private Vector3 pos;
    private Vector3 screen_pos;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = PlayerController.GetPlayerPos();
        PlaceAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceAsteroid()
    {
        Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
        Instantiate(chosen_asteroid, new Vector3(0, 0, 0), Quaternion.identity, transform.parent);
    }

    private void FlyAsteroid()
    {
        
    }
}
