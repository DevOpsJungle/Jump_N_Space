using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] TextMeshPro score;
    [SerializeField] private TextMeshProUGUI valueNotSavedText;
    private static int locHighscore;
    [SerializeField] GameObject helpButton, valueSaved, valueNotSaved, deathCluster;
    [SerializeField] private TextMeshProUGUI textBox;
    private StreamReader reader;
    private StreamWriter writer;
    private string[] currentSplitLine;
    private int rank, buttonCheck, fail;
    // Start is called before the first frame update
    void Start()
    {
        buttonCheck = 0;
        valueNotSavedText.text = "Value not saved!";
        try
        {
            reader = new StreamReader(@"highscore.txt");
        }
        catch
        {
            fail = 1;
            valueNotSavedText.text = "No highscore file accessible!";
            valueNotSaved.SetActive(true);
        }
        helpButton.SetActive(false);
        locHighscore = Convert.ToInt32(Highscore.GetHighscore());
        score.text = "Score: "+locHighscore;
        if (fail != 1)
        {
            for (int i = 0; i < 10; i++)
            {
                string currentLine = reader.ReadLine();
                currentSplitLine = currentLine.Split(' ');
                for (int j=0; j < 2; j++)
                {
                    HighscoreMenu.HighscoreList(j, i, currentSplitLine[j]);
                }
            }
            reader.Close();
            
            for (int i = 0; i < 10; i++)
            {
                if ((HighscoreMenu.HighscoreList(0, i)=="Init"))
                {
                    i = NewHighscore(i);
                }
                else if (locHighscore > Int32.Parse(HighscoreMenu.HighscoreList(1, i)))
                {
                    i = NewHighscore(i);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int NewHighscore(int i)
    {
        deathCluster.SetActive(true);
        rank = i;
        i = 9;
        return i;
    }

    public void SubmitHighscore()
    {
        int fail=0;
        try
        {
            writer = new StreamWriter(@"highscore.txt", false);
        }
        catch
        {
            fail = 1; 
            valueNotSavedText.text = "No highscore file accessible!";
            valueNotSaved.SetActive(true);
        }

        if (fail == 0)
        {
            if (buttonCheck == 0)
            {
                for (int i = 8; i >= rank; i--)
                {
                    HighscoreMenu.HighscoreList(0, i + 1, HighscoreMenu.HighscoreList(0, i));
                    HighscoreMenu.HighscoreList(1, i + 1, HighscoreMenu.HighscoreList(1, i));
                }
            }
            HighscoreMenu.HighscoreList(0, rank, textBox.text);
            HighscoreMenu.HighscoreList(1, rank, locHighscore.ToString());
            for (int i = 0; i < 10; i++)
            {
                writer.WriteLine(HighscoreMenu.HighscoreList(0,i)+" "+HighscoreMenu.HighscoreList(1,i)); 
            }
            writer.Close();
            valueSaved.SetActive(true);
            buttonCheck = 1;
        }
    }
}
