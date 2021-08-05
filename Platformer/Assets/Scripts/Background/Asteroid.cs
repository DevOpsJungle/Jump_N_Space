/*
 * Script: Asteroid
 * Author: Felix Schneider
 * Last Change: 02.08.21
 * Handles the asteroid placement with different approaches
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Viewport;
using Random = UnityEngine.Random;

namespace Background
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private List <Transform> asteroid_list;    /*SerializeField show im Unity inspector https://stackoverflow.com/a/53192557 */

        [SerializeField] private int number;            /*number of asteroids that are to be placed*/
        [SerializeField] private bool viewport;
        [SerializeField] private bool deathwall;
    
        [SerializeField] private bool position;
        [SerializeField] private Vector3 pos;
    
    
        /*Delegate is a container for one or many Methods that can be used as a variable*/
        delegate Vector3 DelegateRandom();              /*Delegate declaration*/         
        private DelegateRandom delegate_random;
    
        private void Awake()
        {
            if (viewport.Equals(deathwall) && viewport.Equals(position))
            {
                Debug.LogException(new Exception("Either Viewport or Deathwall or Position"));
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(Wait(0.01f));
        }
    

        private IEnumerator Wait(float t)
        {
            yield return new WaitForSeconds(t);

            InitPlace(number);
        }

        private void InitPlace(int num)
        {
            if (viewport)
            {
                delegate_random = VectorRandViewport;
            }
            else if (deathwall)
            {
                delegate_random = VectorRandY;
            }
            else if (position)
            {
                delegate_random = VectorViewport;
            }
            PlaceAsteroid(delegate_random,num);
        }
    
        private void PlaceAsteroid(DelegateRandom del, int num)             /* Method actually Placing Asteroid with the desired position declared in delegate_random*/
        {
            for (int i = 0; num > i; i++)
            {
                Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
                Instantiate(chosen_asteroid, del.Invoke() , Quaternion.identity, transform);
            }
        }

    
        /* Three Methods for the user of the Unity Inspector to set the position of Asteroids*/
        private Vector3 VectorRandViewport()        /*Random position respective to the Player and the Viewport*/
        {
            float w = Random.Range(-(ScreenViewport.GetWidth()/2), ScreenViewport.GetWidth()/2);        
            float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
            Vector3 rand = new Vector3(w, h, 0);
            Vector3 center = CameraView.GetScreenPos();
            Vector3 v = center + rand;
            return v;       
        }

        private Vector3 VectorRandY()               /*Random position respective to the Player and the Viewport but only along the y axis*/
        {
            float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
            Vector3 rand = new Vector3(0, h, 0);
            //Debug.Log(h);
            //Vector3 center = new Vector3(0,CameraView.GetScreenPos().y,0);
            //Vector3 v = center + rand;
            return rand;        
        }

        private Vector3 VectorViewport()            /*Manual position respective to the Viewport (in Viewportspace)*/
        {
            Vector3 v = CameraView.GetCamera().ViewportToWorldPoint(pos);
            return v;       
        }
    }
}
