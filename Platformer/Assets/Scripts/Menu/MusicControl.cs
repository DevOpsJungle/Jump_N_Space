/*
 * Script: MusicControl
 * Author: Philip Noack
 * Last Change: 12.06.21
 * load the soundtrack object in other scenes
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Soundtrack"); /*the soundtrack will not destroyed after change the scene and dont load twice, if the player change the scene again*/
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject); 
    }
}
