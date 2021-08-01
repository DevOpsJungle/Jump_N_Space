/*
 * Script: Help Screen
 * Author: Johannes Wilhelm, Philip Noack
 * Last Change: 21.06.2021
 * bind ESC, controls status HelpUI and load Help- and Pausemenu
 */

using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public GameObject ui;
    public List<GameObject> ui;
    [SerializeField] private GameObject HelpButton;
    [SerializeField] private GameObject HelpUI;

    public bool bind_to_key;
    public KeyCode key;


    private void Awake()
    {
        HelpButton = GameObject.FindWithTag("HelpButton");
        HelpUI = GameObject.FindWithTag("HelpUI");
    }

    private void Start()
    {
        foreach (var game_object in ui)
        {
            game_object.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HelpUI.activeSelf) //check if the HelpUi is active
        {
            bind_to_key = false; //ESC will ignore
        }
        else
        {
            bind_to_key = true; //ESC can be used normally
        }
        if (bind_to_key == true)
        {
            KeyBind();
        }
    }

    private void KeyBind()
    {
        {
           if (Input.GetKeyDown(key))
           {
               if (GameController.game_is_paused) {
                   ShowHelp();
                   Resume();
               }
               else {
                   Pause();
                   HideHelp();
               }
           } 
        }
    }

    public void Resume()
    {
        foreach (var game_object in ui)
        {
            game_object.SetActive(false);
        }
        ShowHelp();
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

    public void HideHelp() //hide Helpbutton if Pausemenu is active
    {
        HelpButton.SetActive(false);
    }
    public void ShowHelp() //show Helpbutton if Pausemenu isn´t active
    {
        HelpButton.SetActive(true);
    }
}

    
 