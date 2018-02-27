using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpMiniGame : MonoBehaviour, IResetUser, IResetStation
{
    // UI, the variables required for the UI.
    public Slider gauge;
    public Image filled;
    public Text completionText;

    // Completion mechanics, the variables required to keep track of completion for the minigame.
    public int completionCount = 100;
    private float completionCounter = 0;
    private bool buttonXLastPressed = false;
    public int completionValue = 5;
    public bool isComplete = false;

    public float clickvalue = 5f;   // How much does the slider move each button click

    //variables and gameobjects for the station.
    public Interactable station; 
    private string stationUser = "";

    //resets the station before play. 
    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0;
    }

    //resets the user.
    public void ResetUser()
    {
        stationUser = "";
    }

    /// <summary>
    /// if the game is paused the minigame is disabled, and the check completion and handle Input is only run if the game isn't already
    /// completed. 
    /// </summary>
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
            completionCounter -= 10f * Time.deltaTime;
        UpdateGauge();
    }

    //updates the gauge.
    void UpdateGauge()
    {
        gauge.value = completionCounter;
        //filled.rectTransform.sizeDelta = new Vector2(80, completionCounter + 104);
        filled.rectTransform.sizeDelta = Vector2.Lerp(new Vector2(80, 104), new Vector2(80, 291), completionCounter/100);
        completionText.text = completionCounter.ToString("#");
    }

    /// <summary>
    /// handles player input and makes sure you can't hold in the x-button to complete the game. Updates the gauge every time the correct button is pressed. 
    /// </summary>
    void HandlePlayerInput()
    {

        if (stationUser == "")
            return;

        if (Input.GetButtonDown("X-button" + stationUser) && buttonXLastPressed == false)
        {
            completionCounter += clickvalue;
            buttonXLastPressed = true;
            UpdateGauge();
            AudioManager.instance.Play("Type");
        }

        if (Input.GetButtonDown("Y-button" + stationUser) && buttonXLastPressed == true)
        {
            completionCounter += clickvalue;
            buttonXLastPressed = false;
            UpdateGauge();
            AudioManager.instance.Play("Type");
        }

    }

    /// <summary>
    /// checks for the completion criteria and runs the CompleteMiniGame Coroutine if the criteria is met.
    /// </summary>
    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            completionText.text = "Done";
            station.AddHealthToStation(completionValue);
            isComplete = true;
            stationUser = "";

            station.MiniGameComplete();

            AudioManager.instance.Play("Pling");
        }
    }
}
