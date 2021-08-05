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

        private static string[,] highscoreList = new string[2,10];
    
        private string[] currentSplitLine;
        private int empty = 0;
    
        public static char split = '';
        public static string path;

        private StreamReader reader;
        private StreamWriter writer;

        private int fail = 0;
    
    
        private void Awake()
        {
            path = @"highscore.txt";
        }

        // Start is called before the first frame update
        void Start()
        {
            if (!File.Exists(path))
            {
                using (var init = File.CreateText(path))
                {
                    for (var i = 0; i < 10; i++)
                    {
                        init.WriteLine("Init"+split+"0");
                    }
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
                errorText.text = "No highscore file accessible!";
                error.SetActive(true);
            }

        
        
            if (fail != 1)
            {
                for (var i = 0; i < 10; i++)
                {
                    var currentLine = reader.ReadLine();

                    if (currentLine != null)
                    {
                        currentSplitLine = currentLine.Split(split);
                        try
                        {
                            for (var j = 0; j < 2; j++) HighscoreList(j, i, currentSplitLine[j]);
                        }
                        catch
                        {
                            errorText.text = "Highscore file corrupt!";
                            error.SetActive(true);
                            fail = 1;
                        }
                    }
                }
                reader.Close();
            
            
            
                for (int i = 0; i < 10; i++)
                {
                    if (HighscoreList(0, i) != "Init")
                    {
                        textList[i].text = (i+1)+".  "+HighscoreList(0, i) + "    " + HighscoreList(1, i);
                    }
                    else
                    {
                        empty++;
                    }
                }

                if (empty == 10)
                {
                    errorText.text = "No Highscores Yet, Play to Fill!";
                    error.SetActive(true);
                }
            }
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
}
