using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    public Slider gauge;
    public Text completionText;
    public int completionCount = 100;
    private float completionCounter = 0;
    public int completionValue = 5;

    public float clickvalue = 5f;   

    public Interactable station;
    public bool isComplete = false;

    private string stationUser = "";

    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0;
    }

    public void ResetUser()
    {
        stationUser = "";
    }

    void Update()
    {
        if (isComplete || stationUser == "")
            return;

        DropDown();
        CheckCompletionCriteria();
        HandlePlayerInput();
    }

    void DropDown()
    {
        if(completionCounter > 1)
            completionCounter -= .1f;
        UpdateGauge();
    }

    void UpdateGauge()
    {
        gauge.value = completionCounter;
        completionText.text = completionCounter.ToString("#");
    }

    void HandlePlayerInput()
    {

        if (stationUser == "")
            return;

        if (Input.GetButtonDown("X-button" + stationUser))
        {
            completionCounter += clickvalue;
            UpdateGauge();
        }

    }

    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            completionText.text = "Done";
            StartCoroutine(CompleteMiniGame());
        }
    }

    IEnumerator CompleteMiniGame()
    {
        station.AddHealthToStation(completionValue);
        isComplete = true;
        stationUser = "";

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }
}
