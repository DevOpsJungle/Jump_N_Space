/*
 * Script: Help Screen
 * Author: Johannes Wilhelm
 * Last Change: 21.06.2021
 * ...I am a description...
 */

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameObject pause_ui;

    private void Start()
    {
        pause_ui = GameObject.Find("PauseUI");
        pause_ui.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
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
