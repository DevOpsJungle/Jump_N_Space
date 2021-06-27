/*
 * Script: MainMenu
 * Author: Philip Noack
 * Last Change: 12.06.21
 * Play and Quit Button in Menu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public string scenename;  /*name of the gamescene*/

   public void StartScene()
   {
      SceneManager.LoadScene(scenename); /*load the scene*/
   }

   public void QuitGame()
   {
      Debug.Log("QuitTest"); /*only for debugging*/
      Application.Quit(); /*close the game*/
   }
   
}