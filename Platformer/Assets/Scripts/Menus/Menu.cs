/*
 * Script: Menu
 * Author: Philip Noack
 * Last Change: 12.06.21
 * Source: https://www.youtube.com/watch?v=zc8ac_qUXQY
 * Play and Quit Button in Menu
 */


using Global;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
   public class Menu : MonoBehaviour
   {
      public string scenename; /*name of the gamescene*/
   
      public void StartScene()
      {
         SceneManager.LoadScene(scenename); /*load the scene*/
         GameController.TimeStart();
      }

      public void QuitGame()
      {
         Debug.Log("QuitTest"); /*only for debugging*/
         Application.Quit(); /*close the game*/
      }
   
   }
}