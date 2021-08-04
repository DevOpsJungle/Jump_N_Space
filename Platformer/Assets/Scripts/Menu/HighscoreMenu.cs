
using UnityEngine;


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
        return highscoreList[x,y];
    } 
    public static void HighscoreList(int x, int y, string b)
    {
        highscoreList[x, y] = b;
    } 
}
