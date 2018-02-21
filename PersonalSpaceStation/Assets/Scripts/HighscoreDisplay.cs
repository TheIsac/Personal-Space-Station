using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour {

    public Text[] scores;
    private int highscoreCount = 5;

    void Start()
    {
        DownLoadHighscores();

        //for (int i = 0; i < highscoreCount; i++)
        //{
        //    PlayerPrefs.SetString("PlayerName" + i, "Empty");
        //    PlayerPrefs.SetInt("Highscore" + i,  1);
        //}
    }

    void DownLoadHighscores()
    {

        for (int i = 0; i < highscoreCount; i++)
        {
            string name = PlayerPrefs.GetString("PlayerName" + i);

            if(name == "")
            {
                name = "Unknown";
            }
            scores[i].text = name + ": " +PlayerPrefs.GetInt("Highscore" + i).ToString("0");
        }
    }
}
