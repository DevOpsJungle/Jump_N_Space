using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform chunk_start;
    [SerializeField] private List <Transform> chunk_list;
    [Range(0, 10f)] [SerializeField] private int startchunks;
    [Range(0, 500f)] [SerializeField] private int chunkvisibility;
    
    private GameObject player; //Krücke

    private Vector3 lastendposition;
    
    private void Awake()
    {
        player = GameObject.Find("PlayerNameHere"); //Krücke
        
        Instantiate(chunk_start, new Vector3(-17, -10, 0), Quaternion.identity);
        
        lastendposition = chunk_start.Find("EndPosition").position;

        for (int i = 0; i < startchunks - 1; i++)
        {
            PlaceChunk();
        }
        
    }

    private void Update()
    {
        if (Vector3.Distance( player.transform.position, lastendposition) < chunkvisibility) //nicht funktionabel
        {
            PlaceChunk();
        }
    }

    private void PlaceChunk()
    {
        Transform chosenchunk = chunk_list[Random.Range(0, chunk_list.Count)];
        Transform lastchunktransform = PlaceChunk(chosenchunk, lastendposition);
        lastendposition = lastchunktransform.Find("EndPosition").position;
    }

    private Transform PlaceChunk(Transform chunkpart, Vector3 spawnposition)
    {
        Transform chunktransform = Instantiate(chunkpart, spawnposition, Quaternion.identity);
        return chunktransform;
    }
}
