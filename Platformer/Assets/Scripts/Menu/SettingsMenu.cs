/*
 * Script: SettingsMenu
 * Author: Philip Noack
 * Last Change: 15.06.21
 * Source: https://answers.unity.com/questions/1463609/screenresolutions-returning-duplicates.html
 * Volume and Resolution control in OptionsMenu
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

public class SettingsMenu : MonoBehaviour 
{
    public AudioMixer mixer;
    public Slider slider;
    public Dropdown resolutionsdropdown;
    private Resolution mon_resolution;
    private Resolution[] resolutions;
    public Toggle fullscreenToggle;

    private int index = 0;

    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f); /*get current slider value*/
        
        mon_resolution = Screen.currentResolution;
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); /*filter for unique height and width results, before all resolutions were twice (source)*/
        
        resolutionsdropdown.ClearOptions();
        List<string> options = new List<string>(); /*new string for dropdownmenu*/

        
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            int aspectratio = resolutions[i].width % resolutions[i].height; /* check if calculated resolution has an aspect ratio from 16:9 (16 mod 9 = 7)*/
            if (aspectratio % 7 == 0)    
            {
                string option = resolutions[i].width + "x" + resolutions[i].height; /*add resolutions to dropdownmenu*/
                options.Add(option);
            }
            
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) /*current display resolution, will be automatically game resolution*/
            {
                currentResolutionIndex = i;
            } 
        }
        resolutionsdropdown.AddOptions(options);
        resolutionsdropdown.value = currentResolutionIndex;
        resolutionsdropdown.RefreshShownValue();
        
        fullscreenToggle.isOn = Screen.fullScreen;
    }
    
    
    public void SetVolume (float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20); /*calculate new volume (log function because the audio mixer value is logarithmic*/
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);  /*save volume settings*/
    }

    public void SetResolution(int resolutionIndex)
    {
        index = resolutionIndex;
        
        Resolution resolution = resolutions[resolutionIndex];

        if (Screen.fullScreen == true)
        {
            //Screen.SetResolution(mon_resolution.width, mon_resolution.height,FullScreenMode.Windowed);
            Screen.SetResolution(resolution.width,resolution.height,FullScreenMode.FullScreenWindow);
        }
        else
        {
            Screen.SetResolution(resolution.width,resolution.height,FullScreenMode.Windowed);
        }
        
        //Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen); /*set chosen resolution and activate fullscreen*/
        
        /*Screen.SetResolution(2560,1440,FullScreenMode.Windowed);
        Screen.SetResolution(2560,1440,FullScreenMode.FullScreenWindow);*/
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Resolution resolution = resolutions[index];
        
        if (isFullscreen == true)
        {
            Screen.SetResolution(mon_resolution.width, mon_resolution.height,FullScreenMode.FullScreenWindow);
        }
        else
        {
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
        }
        
        //Screen.fullScreen = isFullscreen;
    }
} 
