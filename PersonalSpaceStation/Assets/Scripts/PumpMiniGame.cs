using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpMiniGame : MonoBehaviour, IResetUser, IResetStation
{
    // UI
    public Slider gauge;
    public Text completionText;

    // Completion mechanics
    public int completionCount = 100;
    private float completionCounter = 0;
    private bool buttonXLastPressed = false;
    public int completionValue = 5;
    public bool isComplete = false;

    public float clickvalue = 5f;   // How mouch does the slider move each button click

    public Interactable station;
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
        if (GameManager.instance.gameIsPaused == true)
        {
            return;
        }
        else
        {
            if (isComplete || stationUser == "")
                return;

            DropDown();
            CheckCompletionCriteria();
            HandlePlayerInput();
        }
    }

    // The gauge slowly returns to zero
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

        if (Input.GetButtonDown("X-button" + stationUser) && buttonXLastPressed == false)
        {
            completionCounter += clickvalue;
            buttonXLastPressed = true;
            UpdateGauge();
        }

        if (Input.GetButtonDown("Y-button" + stationUser) && buttonXLastPressed == true)
        {
            completionCounter += clickvalue;
            buttonXLastPressed = false;
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
