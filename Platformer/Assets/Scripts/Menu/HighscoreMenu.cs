using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMenu : MonoBehaviour
{
    public static string[,] highscoreList = new string[2,10];
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public static string HighscoreList(int x, int y)
    {
        Debug.Log(x);
        Debug.Log(y);
        return highscoreList[x,y+1];
    } 
    public static void HighscoreList(int x, int y, string b)
    {
        highscoreList[x, y] = b;
    } 
}
