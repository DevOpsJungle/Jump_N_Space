/*
 * Script: Help Screen
 * Author: Johannes Wilhelm
 * Last Change: 21.06.2021
 * ...I am a description...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Helpscreen : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameObject pause_ui;

    private void Start()
    {
        pause_ui = GameObject.Find("HelpUI");
        pause_ui.SetActive(false);
    }
    
    public void Resume()
    {
        pause_ui.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()

    {
        pause_ui.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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