/*
 * Script: Octopus
 * Author: Felix Schneider
 * Last Change: 02.08.21
 * Handles Octopus Instantiation and Movement
 */


using Global;
using Player;
using UnityEngine;

namespace Background
{
    public class Octopus : MonoBehaviour
    {
        [SerializeField] private GameObject octopus;
        private GameObject octopus_instance;

        private Vector3 pos;

        private void Awake()
        {
            pos = new Vector3(PlayerSpawn.edge_death, GameController.GetStartPos().y, GameController.GetStartPos().z);       /* position dependent on StartPos and Deathwall */
        }

        // Start is called before the first frame update
        private void Start()
        {
            octopus_instance = Instantiate(octopus, pos, Quaternion.identity,transform);    /* creates the object everytime the script is executed */
        }

        // Update is called once per frame
        private void Update()
        {
            octopus_instance.transform.position = new Vector3(PlayerSpawn.edge_death, PlayerSpawn.Lerp(octopus_instance.transform.position.y ,PlayerController.GetPlayerPos().y), 0);
        }
    }
}
