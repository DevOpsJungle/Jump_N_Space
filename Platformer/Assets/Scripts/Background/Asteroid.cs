/*
 * Script: Asteroid
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private List <Transform> asteroid_list;

    [SerializeField] private int number;
    [SerializeField] private bool random;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop());
         
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScreenViewport.GetWidth());
        Debug.Log(ScreenViewport.GetHeight());
    }

    private void PlaceAsteroid(bool b)
    {
        for (int i = 0; number >= i; i++)
        {
            Transform chosen_asteroid = asteroid_list[Random.Range(0, asteroid_list.Count)];
                    if (b == true)
                    {
                        Instantiate(chosen_asteroid, Vector3Random(), Quaternion.identity, transform);
                    }
                    else
                    {
                        Instantiate(chosen_asteroid, Vector3.zero, Quaternion.identity, transform);
                    }
        }
    }

    private Vector3 Vector3Random()
    {
        float w = Random.Range(-(ScreenViewport.GetWidth()/2), ScreenViewport.GetWidth()/2);
        float h = Random.Range(-(ScreenViewport.GetHeight()/2), ScreenViewport.GetHeight()/2); 
        
        Vector3 rand = new Vector3(w, h, 0);
        Vector3 center = CameraView.GetScreenPos();
        Vector3 s = center + rand;
        
        Debug.Log(s);
        return s;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        PlaceAsteroid(random);
    }
}
