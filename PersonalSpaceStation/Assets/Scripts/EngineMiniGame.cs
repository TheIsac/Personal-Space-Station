using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMiniGame : MonoBehaviour, IResetUser, IResetStation
{
    // UI, the variables required for the UI.
    public Image spak;
    public Text completionText;

    // Completion mechanics, the variables required for the minigame involving completion.
    public bool isComplete = false;
    public float completionTime = 3f;
    public int completionValue = 5;
    private float completionCounter = 0f;
    private float minCompletionAngle = 5f;
    private float maxCompletionAngle = 355f;

    // Lever mechanics, the variables controlling the lever.
    private float currentMomentum;
    private float baseMomentum = .5f;
    private float adjusterValue = .01f;

    // Other, the variables for the station and the users, also for the startRotation of the spak.
    private string stationUser = "";
    public Interactable station;
    private Quaternion startRotation;

/// <summary>
/// sets the startRotation to the transform of the spak at the beginning and randoms the currentMomentum. 
/// </summary>
    void Start ()
    {
        startRotation = spak.rectTransform.localRotation;
        currentMomentum = Random.Range(-baseMomentum, baseMomentum);
    }

/// <summary>
/// Resets the minigame before a new game, sets the completion and current momentum to 0f and the start rotation to the correct value. 
/// </summary>
/// <param name="player"></param>
    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0f;
        currentMomentum = 0f;
        spak.rectTransform.localRotation = startRotation;
        completionText.text = completionCounter.ToString("0.0");
    }

/// <summary>
/// Resets the station user. 
/// </summary>
    public void ResetUser()
    {
        stationUser = "";
    }

/// <summary>
/// If the game is paused the minigame is disabled sort of.
/// </summary>
    void Update () {
        if (GameManager.instance.gameIsPaused == true)
        {
            return;
        }
        else
        {
            if (isComplete || stationUser == "")
                return;

            CheckCompletionCriteria();
            MoveLever();
            HandlePlayerInput();
        }
    }

/// <summary>
/// Check the player input and change the spak's location depending on the players input, but only if the station is used.
/// </summary>
    void HandlePlayerInput()
    {
        if (stationUser == "")
            return;
        
        float horizontalAxis = 0;
        
        //if (Mathf.Abs(Input.GetAxis("Horizontal" + stationUser)) > .7f)
        horizontalAxis = Input.GetAxis("Horizontal" + stationUser);

        if (horizontalAxis < -.1f && (spak.rectTransform.localRotation.eulerAngles.z < 90f || spak.rectTransform.localRotation.eulerAngles.z > 200f))
        {
            currentMomentum = baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
        if (horizontalAxis > .1f && (spak.rectTransform.localRotation.eulerAngles.z < 120f || spak.rectTransform.localRotation.eulerAngles.z > 270f))
        {
            currentMomentum = -baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
    }

/// <summary>
/// Check if the player has reached the criteria for the completion of the game. And starts the Coroutine CompleteMiniGame if the player has. 
/// </summary>
    void CheckCompletionCriteria()
    {
        // Check if the mini game is complete
        if(completionCounter >= completionTime)
        {
            station.AddHealthToStation(completionValue);
            isComplete = true;
            stationUser = "";

            station.MiniGameComplete();
            AudioManager.instance.Play("Pling");
        }

        // Update progress if the lever is within green area
        if(spak.rectTransform.localRotation.eulerAngles.z < minCompletionAngle || spak.rectTransform.localRotation.eulerAngles.z > maxCompletionAngle)
        {
            completionCounter += Time.deltaTime;
            completionText.text = completionCounter.ToString("0.0");
        }
    }

/// <summary>
/// The method for moving the lever. 
/// </summary>
    void MoveLever()
    {
        // if the lever is moving slowly, set a random movement
        if(Mathf.Abs(currentMomentum) < 0.1f)
        {
            currentMomentum = Random.Range(-baseMomentum, baseMomentum);
        }
        else if(Mathf.Sign(currentMomentum) > 0)
        {
            currentMomentum += adjusterValue;
        }
        else
        {
            currentMomentum -= adjusterValue;
        }

        // Only move the lever if it is between 90 and -90 degrees
        if(spak.rectTransform.localRotation.eulerAngles.z < 90f || spak.rectTransform.localRotation.eulerAngles.z > 270f)
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
    }
}
