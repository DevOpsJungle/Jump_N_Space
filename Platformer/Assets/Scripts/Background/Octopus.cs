using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{

    [SerializeField] private GameObject octopus;
    private GameObject octopus_instance;

    private Vector3 start_pos;
    private float lerp_speed = 1f;

    private void Awake()
    {
        start_pos = new Vector3(PlayerSpawn.edgedeath, GameController.GetStartPos().y, GameController.GetStartPos().z);
        octopus_instance = Instantiate(octopus, start_pos, Quaternion.identity,transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerSpawn.edgedeath,start_pos.y,start_pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        octopus_instance.transform.position = new Vector3(PlayerSpawn.edgedeath, Lerp(octopus_instance.transform.position ,PlayerController.GetPlayerPos()), start_pos.z);
    }

    private float Lerp(Vector3 last, Vector3 player_pos)
    {
        
        float value;
        //Time.deltaTime * speed
        value = Mathf.Lerp(last.y, player_pos.y, Time.deltaTime * lerp_speed);
        return value;
    }
}
