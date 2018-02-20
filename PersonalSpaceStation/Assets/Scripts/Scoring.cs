using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public float scoreTimer = 0;
    public int totalScore = 0;
    public Text scoreText;
    private int scoreUpdateInterval = 6;
    public float scoreMultiplier = 1;

    public Interactable[] stations;

    private int runningStations;
    private int oldHighScore;

    private int[] highscores;
    private int highscoreCount = 5;

    private string[] highscoreName;

    private void Start()
    {
        DownLoadHighscores();

        for (int i = 0; i < stations.Length; i++)
        {
            stations[i].OnStationFailure += OnStationFailure;
            stations[i].OnStationFixed += OnStationRunning;
        }

        oldHighScore = PlayerPrefs.GetInt("HighScore", 0);

    }

    void Update()
    {

        if (Time.frameCount % scoreUpdateInterval == 0)
        {
            UpdateMultiplyer();
        }
        scoreTimer += Time.deltaTime * scoreMultiplier;
        totalScore = (int)scoreTimer;

        scoreText.text = "Score: " +totalScore.ToString("000000");
    }

    public void SortHighscores(string currentPlayer)
    {
        for (int i = highscoreCount - 1; i >= 0; i--)
        {
            if(totalScore > highscores[i])
            {
                if(i < highscoreCount - 1)
                {
                    highscores[i + 1] = highscores[i];
                    highscoreName[i + 1] = highscoreName[i];
                }
                highscores[i] = totalScore;
                highscoreName[i] = currentPlayer;
            }
        }

        for (int i = 0; i < highscoreCount; i++)
        {
            PlayerPrefs.SetInt("Highscore" + i, highscores[i]);
            PlayerPrefs.SetString("PlayerName" + i, highscoreName[i]);
        }
    }

    void DownLoadHighscores()
    {
        highscores = new int[highscoreCount];
        highscoreName = new string[highscoreCount];
        for (int i = 0; i < highscoreCount; i++)
        {
            highscores[i] = PlayerPrefs.GetInt("Highscore" + i);
            highscoreName[i] = PlayerPrefs.GetString("PlayerName" + i);
        }
    }

    void UpdateMultiplyer()
    {
        if (runningStations==1)
        {
            scoreMultiplier = 1f;
        }
        else if(runningStations == 2)
        {
            scoreMultiplier = 1.5f;
        }
        else if (runningStations == 3)
        {
            scoreMultiplier = 2.5f;
        }
        else if (runningStations == 4)
        {
            scoreMultiplier = 4f;
        }

    }
    void OnStationFailure()
    {
        //Remove station from runningStations
        if (runningStations != 1)
        {
            runningStations -= 1;
        }
    }
    void OnStationRunning()
    {
        //Add station to runningStations
        if (runningStations != 4)
        {
            runningStations += 1;
        }
    }
}
