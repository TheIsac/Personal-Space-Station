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


    private void Start()
    {
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

        // Save the high score data if the score is indeed higher than the previous one
        if (totalScore > oldHighScore)
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
            oldHighScore = totalScore;
        }

        scoreText.text = totalScore.ToString();
    }

    //Add score based on number of runningStations
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
