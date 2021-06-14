/*
 * Script: World Generator
 * Author: Felix Schneider, Vincent Becker
 * Last Change: 14.06.21
 * This script creates the world at random using predefined chunks
 */

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
    
    private Vector3 pos;
    private Vector3 lastendposition;
    
    private void Awake()
    {
        //lastendposition = chunk_start.Find("EndPosition").position;
        lastendposition = chunk_start.Find("EndPosition").GetComponent<Transform>().position;
    }

    private void Start()
    {
        pos = PlayerController.player_pos;
        Instantiate(chunk_start, new Vector3(0, 0, 0), Quaternion.identity, transform.parent);
        
        for (int i = 0; i < startchunks - 1; i++)
        {
            PlaceChunk();
        }
    }

    private void Update()
    {
        pos = PlayerController.player_pos;
        
        if (Vector3.Distance( pos, lastendposition) < ScreenViewport.width/2 + chunkvisibility)
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
        Transform chunktransform = Instantiate(chunkpart, spawnposition, Quaternion.identity, transform.parent);
        return chunktransform;
    }
}
