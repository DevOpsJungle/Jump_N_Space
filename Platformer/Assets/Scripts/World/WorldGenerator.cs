/*
 * Script: WorldGenerator
 * Author: Felix Schneider, Vincent Becker
 * Last Change: 14.06.21
 * This script creates the world at random using predefined chunks
 */


using System.Collections.Generic;
using Player;
using Viewport;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform chunk_start;
    [SerializeField] private List <Transform> chunk_list;
    [Range(0, 10f)] [SerializeField] private int start_chunks;
    [Range(0, 500f)] [SerializeField] private int chunk_visibility;
    
    private Vector3 pos;
    private Vector3 last_end_pos;
    
    private void Awake()
    {
        last_end_pos = chunk_start.Find("EndPosition").GetComponent<Transform>().position;
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
        
        if (Vector3.Distance( pos, last_end_pos) < ScreenViewport.GetWidth()/2 + chunk_visibility)
        {
            PlaceChunk();
        }
    }

    private void PlaceChunk()
    {
        Transform chosenchunk = chunk_list[Random.Range(0, chunk_list.Count)];
        Transform lastchunktransform = PlaceChunk(chosenchunk, last_end_pos);
        last_end_pos = lastchunktransform.Find("EndPosition").position;
    }

    private Transform PlaceChunk(Transform chunk_part, Vector3 spawn_pos)
    {
        Transform chunktransform = Instantiate(chunk_part, spawn_pos, Quaternion.identity, transform.parent);
        return chunktransform;
    }
}
