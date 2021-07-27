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

    [SerializeField] private int number;
    [SerializeField] private bool random_viewport;
    [SerializeField] private bool random_deathwall;


    private void Awake()
    {
        if (random_viewport == random_deathwall)
        {
            Debug.LogException(new Exception("Either random_viewport or random_deathwall"));
        }
    }

    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScreenViewport.GetWidth());
        Debug.Log(ScreenViewport.GetHeight());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        if (random_viewport)
        {
            PlaceAsteroid(RandomViewport());
        }
        else if (random_deathwall)
        {
            PlaceAsteroid(RandomDeathwall());
        }
        else
        {
            PlaceAsteroid(new Vector3(0,0,0));
        }
    }
    
    private void PlaceAsteroid(Vector3 v)
    {
        for (int i = 0; number >= i; i++)
        {
            Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
            Instantiate(chosen_asteroid, v, Quaternion.identity, transform);
        }
    }

    private Vector3 RandomViewport()
    {
        float w = Random.Range(-(ScreenViewport.GetWidth()/2), ScreenViewport.GetWidth()/2);
        float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
        Vector3 rand = new Vector3(w, h, 0);
        Vector3 center = CameraView.GetScreenPos();
        Vector3 v = center + rand;
        return v;
    }

    private Vector3 RandomDeathwall()
    {
        float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
        Vector3 rand = new Vector3(0, h, 0);
        Vector3 center = CameraView.GetScreenPos();
        Vector3 v = center + rand;
        return rand;
    }

    
}
