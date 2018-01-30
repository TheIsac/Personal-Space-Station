using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public float scoreTimer = 0;
    public Text scoreText;
    private int scoreUpdateInterval = 6;

    List<string> stations= new List<string>();
    private int runningStations;

    void Update ()
    {
        scoreTimer += Time.deltaTime;
        if (Time.frameCount % scoreUpdateInterval == 0)
        {
            CountRunningStations();
            UpdateScore();
        }

        scoreText.text = scoreTimer.ToString();
	}
    //Check how many stations are running well
    void CountRunningStations()
    {
        //Add station to list, if it is running


        runningStations = stations.Count;

    }
    //Add score based on number of running stations
    void UpdateScore()
    {
        if (runningStations==1)
        {

        }
        else if(runningStations == 2)
        {

        }
        else if (runningStations == 3)
        {

        }
        else if (runningStations == 4)
        {

        }
    }
}
