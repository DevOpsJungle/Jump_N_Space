using System;
using System.IO;
using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject helpButton, valueSaved, valueNotSaved, deathCluster;

    [SerializeField] private TextMeshPro score;

    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private TextMeshProUGUI valueNotSavedText;

    private string[] currentSplitLine;

    private string path;
    private int rank, buttonCheck, fail;
    private static int locHighscore;

    private StreamReader reader;
    private StreamWriter writer;

    private char split;

    private void Awake()
    {
        split = '';
    }

    // Start is called before the first frame update
    private void Start()
    {
        buttonCheck = 0;
        valueNotSavedText.text = "Value not saved!";

        path = @"highscore.txt";

        if (!File.Exists(path))
        {
            using (var init = File.CreateText(path))
            {
                init.WriteLine("Init"+split+"0");
            }

            Debug.Log("dataPath : " + path);
        }
        
        try
        {
            reader = new StreamReader(path);
        }
        catch
        {
            fail = 1;
            valueNotSavedText.text = "No highscore file accessible!";
            valueNotSaved.SetActive(true);
        }


        helpButton.SetActive(false);
        locHighscore = Convert.ToInt32(Highscore.GetHighscore());
        score.text = "Score: " + locHighscore;

        if (fail != 1)
        {
            for (var i = 0; i < 10; i++)
            {
                var currentLine = reader.ReadLine();
                
                if (currentLine != null)
                {
                    currentSplitLine = currentLine.Split(split);
                    Debug.Log(currentSplitLine[0]);
                    Debug.Log(currentSplitLine[1]);
                    for (var j = 0; j < 2; j++) HighscoreMenu.HighscoreList(j, i, currentSplitLine[j]);
                }
            }

            reader.Close();


            for (var i = 0; i < 10; i++)
                if (HighscoreMenu.HighscoreList(0, i) == "Init")
                {
                    i = NewHighscore(i);
                    buttonCheck = 1;        /* overrides the initial highscore */
                }
                else if (locHighscore > int.Parse(HighscoreMenu.HighscoreList(1, i))) i = NewHighscore(i);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private int NewHighscore(int i)
    {
        deathCluster.SetActive(true);
        rank = i;
        i = 9;
        return i;
    }

    public void SubmitHighscore()
    {
        var fail = 0;
        try
        {
            writer = new StreamWriter(path, false);
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
                for (var i = 8; i >= rank; i--)
                {
                    HighscoreMenu.HighscoreList(0, i + 1, HighscoreMenu.HighscoreList(0, i));
                    HighscoreMenu.HighscoreList(1, i + 1, HighscoreMenu.HighscoreList(1, i));
                }

            HighscoreMenu.HighscoreList(0, rank, textBox.text);
            HighscoreMenu.HighscoreList(1, rank, locHighscore.ToString());
            for (var i = 0; i < 10; i++)
            {
                if(HighscoreMenu.HighscoreList(0,i) != null && HighscoreMenu.HighscoreList(1,i) != null)
                {
                    writer.WriteLine(HighscoreMenu.HighscoreList(0, i) + split + HighscoreMenu.HighscoreList(1, i));
                }
            }
                
            writer.Close();
            valueSaved.SetActive(true);
            buttonCheck = 1;
        }
    }
}