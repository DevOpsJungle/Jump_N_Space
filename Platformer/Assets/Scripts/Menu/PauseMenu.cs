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
            if (GameController.game_is_paused)
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
        GameController.TimeStart();
    }

    public void Pause()
    {
        foreach (var game_object in ui)
        {
            game_object.SetActive(true);
        }
        GameController.TimeStop();
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