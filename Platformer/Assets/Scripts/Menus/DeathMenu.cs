/*
* Script: DeathMenu
* Author: Philipp Scheffler
* Last Change: 03.08.21
* Read existing highscores, check for new highscore, write new highscore if necessary
*/

using System;
using System.IO;
using Global;
using TMPro;
using UnityEngine;

namespace Menus
{
    public class DeathMenu : MonoBehaviour
    {
        [SerializeField] private GameObject helpButton, valueSaved, valueNotSaved, deathCluster; //create all gameObjects

        [SerializeField] private TextMeshPro score; //create textObject

        [SerializeField] private TextMeshProUGUI valueNotSavedText, textBox; //create textObjects

        private string[] currentSplitLine;

        private string path = HighscoreMenu.path;

        private int rank, buttonCheck, fail;
        private static int loc_highscore;
    
        private StreamReader reader;
        private StreamWriter writer;
    
        private readonly char split = HighscoreMenu.split; //import seperator from highscoreMenu

        private void Awake()
        {
            buttonCheck = 0;
            valueNotSavedText.text = "Value not saved!";
            path = @"highscore.txt"; //set path for highscore file
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (!File.Exists(path)) //check if highscore file already exists
            {
                using (var init = File.CreateText(path))  //create it at specified path
                {
                    for (var i = 0; i < 10; i++) init.WriteLine("Init" + split + "0"); //fill it with initial values
                    init.Close(); //close StreamWriter
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
                valueNotSavedText.text = "No highscore file accessible!";
                valueNotSaved.SetActive(true);
            }


        
            helpButton.SetActive(false); 
            loc_highscore = Convert.ToInt32(Highscore.GetHighscore()); //import current highscore from game
            score.text = "Score: " + loc_highscore;

        
        
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
                            for (var j = 0; j < 2; j++) HighscoreMenu.HighscoreList(j, i, currentSplitLine[j]); //try writing the contents of the file to the function HighscoreMenu.HighscoreList / array highscoreList
                        }
                        catch
                        {
                            //if the file is corrupt
                            valueNotSavedText.text = "Highscore file corrupt!";
                            valueNotSaved.SetActive(true);
                            fail = 1;
                        }
                    }
                }
                reader.Close();

            

                for (var i = 0; i < 10; i++)
                    if (HighscoreMenu.HighscoreList(0, i) == "Init") //check for initial values
                    {
                        i = NewHighscore(i);
                        buttonCheck = 1; //override the initial highscore
                    }
                    else if (loc_highscore > int.Parse(HighscoreMenu.HighscoreList(1, i))) //check if reached score is a highscore
                    {
                        i = NewHighscore(i);
                    }
            }
        }
    

        private int NewHighscore(int i) //called, if a new highscore was set
        {
            deathCluster.SetActive(true); //set textbox, submit button, highscore text to active
            rank = i; //reached rank
            i = 9; //to exit the for loop
            return i;
        }

        public void SubmitHighscore() //write reached highscore into highscore file
        {
            var fail = 0;
            try
            {
                writer = new StreamWriter(path, false); //override the current file
            }
            catch
            {
                fail = 1;
                valueNotSavedText.text = "No highscore file accessible!";
                valueNotSaved.SetActive(true);
            }

        
        
            if (fail == 0)
            {
                if (buttonCheck == 0) //check if button was already pressed after death
                    for (var i = 8; i >= rank; i--)
                    {
                        HighscoreMenu.HighscoreList(0, i + 1, HighscoreMenu.HighscoreList(0, i)); //shift every entry in the highscoreList array behind the highscore
                        HighscoreMenu.HighscoreList(1, i + 1, HighscoreMenu.HighscoreList(1, i));
                    }

                HighscoreMenu.HighscoreList(0, rank, textBox.text); //write name into  highscoreList array
                HighscoreMenu.HighscoreList(1, rank, loc_highscore.ToString()); //write highscore into  highscoreList array
                for (var i = 0; i < 10; i++)
                {
                    if (HighscoreMenu.HighscoreList(0, i) != null && HighscoreMenu.HighscoreList(1, i) != null) //check if the entries in the array are null
                    { 
                        writer.WriteLine(HighscoreMenu.HighscoreList(0, i) + split + HighscoreMenu.HighscoreList(1, i)); //write array content of each line with seperator into file
                    }
                }
            
                writer.Close();
                valueSaved.SetActive(true); //output success message
                buttonCheck = 1; //set the variable that the button was already pressed to 1
            }
        }
    }
}