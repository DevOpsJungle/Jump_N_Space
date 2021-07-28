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
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private List <Transform> asteroid_list;

    [SerializeField] private int number;
    [SerializeField] private bool random_viewport;
    [SerializeField] private bool random_deathwall;
    
    [SerializeField] private bool position;
    [SerializeField] private Vector3 viewport_pos;
    
    
    delegate Vector3 DeligateRandom();
    private DeligateRandom deligate_random;
    
    private void Awake()
    {
        if (random_viewport.Equals(random_deathwall) && random_viewport.Equals(position))
        {
            Debug.LogException(new Exception("Either random_viewport or random_deathwall or position"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(0.01f));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ScreenViewport.GetWidth());
        //Debug.Log(ScreenViewport.GetHeight());
    }
    
    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);

        InitPlace(number);
    }

    public void InitPlace(int num)
    {
        if (random_viewport)
        {
            deligate_random = VectorRandViewport;
        }
        else if (random_deathwall)
        {
            deligate_random = VectorRandDeathwall;
        }
        else if (position)
        {
            deligate_random = VectorOnScreen;
        }
        PlaceAsteroid(deligate_random,num);
    }
    
    private void PlaceAsteroid(DeligateRandom del, int num)
    {
        for (int i = 0; num > i; i++)
        {
            Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
            Instantiate(chosen_asteroid, del.Invoke() , Quaternion.identity, transform);
        }
    }

    private Vector3 VectorRandViewport()
    {
        float w = Random.Range(-(ScreenViewport.GetWidth()/2), ScreenViewport.GetWidth()/2);
        float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
        Vector3 rand = new Vector3(w, h, 0);
        Vector3 center = CameraView.GetScreenPos();
        Vector3 v = center + rand;
        return v;
    }

    private Vector3 VectorRandDeathwall()
    {
        float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
        Vector3 rand = new Vector3(0, h, 0);
        Debug.Log(h);
        //Vector3 center = new Vector3(0,CameraView.GetScreenPos().y,0);
        //Vector3 v = center + rand;
        return rand;
    }

    private Vector3 VectorOnScreen()
    {
        Vector3 v = CameraView.GetCamera().ViewportToWorldPoint(viewport_pos);
        return v;
    }
}
