/*
 * Script: MusicControl
 * Author: Philip Noack
 * Last Change: 12.06.21
 * Load the soundtrack object in other scenes
 */


using UnityEngine;

namespace Menus
{
    public class MusicControl : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Soundtrack"); /*the soundtrack will not destroyed after change the scene and dont load twice, if the player change the scene again*/
            if (objs.Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
