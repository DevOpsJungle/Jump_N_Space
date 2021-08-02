using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] TextMeshPro score;
    private static int locHighscore;
    [SerializeField] GameObject helpButton, valueSaved, valueNotSaved, deathCluster;
    [SerializeField] private TextMeshPro textBox;

    private int rank, buttonCheck;
    // Start is called before the first frame update
    void Start()
    {
        helpButton.SetActive(false);
        locHighscore = Convert.ToInt32(Highscore.GetHighscore());
        Debug.Log(locHighscore);
        score.text = "Score: "+locHighscore;
        for (int i = 0; i < 9; i++)
        {
            if ((HighscoreMenu.HighscoreList(1, i)==null))
            { 
                i = NewHighscore(i);
            }
            else if (locHighscore <= Int32.Parse(HighscoreMenu.HighscoreList(1, i)))
            {
                i = NewHighscore(i);
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
        Debug.Log(HighscoreMenu.HighscoreList(1,i));
        i = 9;
        return i;
    }

    void SubmitHighscore()
    {
        int worked=0;
        if (buttonCheck == 0)
        {
            buttonCheck = 1;
            
            try
            {

            }
            catch
            {
                worked = 1;
            }

            if (worked == 0)
            {
                HighscoreMenu.HighscoreList(0, rank, textBox.text);
                HighscoreMenu.HighscoreList(1, rank, locHighscore.ToString());
                valueSaved.SetActive(true);
            }
            else
            {
                valueNotSaved.SetActive(false);
            }
            
        }
    }
}
