using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public float scoreTimer = 0;
    public Text scoreText;
    private int scoreUpdateInterval = 6;
    public float scoreMultiplier = 1;

    private int runningStations;

    void Update ()
    {
        if (Time.frameCount % scoreUpdateInterval == 0)
        {
            UpdateScore();
            scoreTimer += Time.deltaTime * scoreMultiplier;
        }

        scoreText.text = scoreTimer.ToString();
	}

    //Add score based on number of runningStations
    void UpdateScore()
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
