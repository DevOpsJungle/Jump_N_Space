/*
 * Script: Help Screen
 * Author: Johannes Wilhelm
 * Last Change: 21.06.2021
 * ...I am a description...
 */

using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public GameObject ui;
    public List <GameObject> ui;
    
    public bool bind_to_key;
    public KeyCode key;

    public static bool game_is_paused;
    
    void Awake()
    {
        game_is_paused = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (bind_to_key == true)
        {
            KeyBind();
        }
    }
    
    private void KeyBind()
    {
        if (Input.GetKeyDown(key))
        {
            if (game_is_paused)
                Resume();
            else
                Pause();
        }
    }
    
    public void Resume()
    {
        foreach (var game_object in ui)
        {
            game_object.SetActive(false);
        }
        
        Time.timeScale = 1f;
        game_is_paused = false;
    }

    public void Pause()
    {
        foreach (var game_object in ui)
        {
            game_object.SetActive(true);
        }
        Time.timeScale = 0f;
        game_is_paused = true;
        Debug.Log("Help pressed!");
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Game...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }
}