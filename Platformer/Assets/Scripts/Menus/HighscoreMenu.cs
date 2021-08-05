/*
* Script: HighscoreMenu
* Author: Philipp Scheffler
* Last Change: 03.08.21
* Read highscore file and display top ten scoreboard
*/

using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace Menus
{
    public class HighscoreMenu : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> textList;
        [SerializeField] private GameObject error;
        [SerializeField] private TextMeshProUGUI errorText;

        private static string[,] highscoreList = new string[2,10]; //array, where highscore names and values are saved
    
        private string[] currentSplitLine;
        private int empty = 0;
    
        public static char split = ''; //cryptic seperator to prevent accidental split
        public static string path;

        private StreamReader reader;
        private StreamWriter writer;

        private int fail = 0;
    
    
        private void Awake()
        {
            path = @"highscore.txt"; //set path of highscore file
        }

        // Start is called before the first frame update
        void Start()
        {
            if (!File.Exists(path)) //check if highscore file already exists
            {
                using (var init = File.CreateText(path)) //create it at specified path
                {
                    for (var i = 0; i < 10; i++) init.WriteLine("Init"+split+"0"); //fill it with initial values
                    init.Close();
                }
            }
        
            try
            {
                reader = new StreamReader(path);
            }
            catch
            {
                //catch error if file is not readable and display it
                fail = 1;
                errorText.text = "No highscore file accessible!";
                error.SetActive(true);
            }

        
        
            if (fail != 1) //if file was not readable before, skip reading
            {
                for (var i = 0; i < 10; i++) //highscore board from 1-10
                {
                    var currentLine = reader.ReadLine();

                    if (currentLine != null)
                    {
                        currentSplitLine = currentLine.Split(split); //split the line into name and matching highscore
                        try
                        {
                            for (var j = 0; j < 2; j++) HighscoreList(j, i, currentSplitLine[j]); //try writing the contents of the file to the function HighscoreMenu.HighscoreList / array highscoreList
                        }
                        catch
                        {
                            //if the file is corrupt
                            errorText.text = "Highscore file corrupt!";
                            error.SetActive(true);
                            fail = 1;
                        }
                    }
                }
                reader.Close();
            
            
            
                for (int i = 0; i < 10; i++)
                {
                    if (HighscoreList(0, i) != "Init") //check for initial values
                    {
                        textList[i].text = (i+1)+".  "+HighscoreList(0, i) + "    " + HighscoreList(1, i); //display highscores
                    }
                    else
                    {
                        empty++; //variable to check if whole table is empty / initial
                    }
                }

                if (empty == 10)
                {
                    errorText.text = "No Highscores Yet, Play to Fill!";
                    error.SetActive(true);
                }
            }
        }
    

        public static string HighscoreList(int x, int y) //function to return array values
        {
            return highscoreList[x,y];
        } 
        public static void HighscoreList(int x, int y, string b) //function to save array values
        {
            highscoreList[x, y] = b;
        } 
    }
}
