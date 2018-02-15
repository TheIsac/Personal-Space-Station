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
    }

    void DownLoadHighscores()
    {

        for (int i = 0; i < highscoreCount; i++)
        {
            scores[i].text = PlayerPrefs.GetInt("Highscore" + i).ToString("0");
        }
    }
}
