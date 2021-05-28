using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public string SceneName;

   public void StartLevel()
   {
      SceneManager.LoadScene(SceneName);
   }

   public void QuitGame()
   {
      Debug.Log("QuitTest");
      Application.Quit();
   }
   
}