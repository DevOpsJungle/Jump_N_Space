/*
 * Script: Octopus
 * Author: Felix Schneider
 * Last Change: 02.08.21
 * Handles Octopus Instantiation and Movement
 */


using UnityEngine;

public class Octopus : MonoBehaviour
{
    [SerializeField] private GameObject octopus;
    private GameObject octopus_instance;

    private Vector3 pos;
    private float lerp_speed = 1f;

    private void Awake()
    {
        pos = new Vector3(PlayerSpawn.edgedeath, GameController.GetStartPos().y, GameController.GetStartPos().z);       /* position dependent on StartPos and Deathwall */
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        octopus_instance = Instantiate(octopus, pos, Quaternion.identity,transform);    /* creates the object everytime the script is executed */
    }

    // Update is called once per frame
    private void Update()
    {
        octopus_instance.transform.position = new Vector3(PlayerSpawn.edgedeath, Lerp(octopus_instance.transform.position ,PlayerController.GetPlayerPos()), pos.z * Time.deltaTime);
    }

    private float Lerp(Vector3 last, Vector3 player_pos)        /* lets the octopus trail behind the player on the y axis */
    {
        float value;
        value = Mathf.Lerp(last.y, player_pos.y, Time.deltaTime * lerp_speed);
        return value;
    }
}
