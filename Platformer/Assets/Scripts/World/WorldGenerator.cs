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
    [Range(0, 10f)] [SerializeField] private int start_chunks;
    [Range(0, 500f)] [SerializeField] private int chunk_visibility;
    
    private Vector3 pos;
    private Vector3 last_end_position;
    
    private void Awake()
    {
        last_end_position = chunk_start.Find("EndPosition").GetComponent<Transform>().position;
    }

    private void Start()
    {
        pos = PlayerController.GetPlayerPos();
        Instantiate(chunk_start, new Vector3(0, 0, 0), Quaternion.identity, transform.parent);
        
        for (int i = 0; i < start_chunks - 1; i++)
        {
            PlaceChunk();
        }
    }

    private void Update()
    {
        pos = PlayerController.GetPlayerPos();
        
        if (Vector3.Distance( pos, last_end_position) < ScreenViewport.GetWidth()/2 + chunk_visibility)
        {
            PlaceChunk();
        }
    }

    private void PlaceChunk()
    {
        Transform chosenchunk = chunk_list[Random.Range(0, chunk_list.Count)];
        Transform lastchunktransform = PlaceChunk(chosenchunk, last_end_position);
        last_end_position = lastchunktransform.Find("EndPosition").position;
    }

    private Transform PlaceChunk(Transform chunkpart, Vector3 spawnposition)
    {
        Transform chunktransform = Instantiate(chunkpart, spawnposition, Quaternion.identity, transform.parent);
        return chunktransform;
    }
}
