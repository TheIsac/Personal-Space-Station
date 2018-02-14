using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMiniGame : MonoBehaviour, IResetUser, IResetStation
{
    // UI
    public Image spak;
    public Text completionText;

    // Completion mechanics
    public bool isComplete = false;
    public float completionTime = 3f;
    public int completionValue = 5;
    private float completionCounter = 0f;
    private float minCompletionAngle = 5f;
    private float maxCompletionAngle = 355f;

    // Lever mechanics
    private float currentMomentum;
    private float baseMomentum = .5f;
    private float adjusterValue = .01f;

    // Other
    private string stationUser = "";
    public Interactable station;
    private Quaternion startRotation;

/// <summary>
/// 
/// </summary>
    void Start ()
    {

        startRotation = spak.rectTransform.rotation;
        currentMomentum = Random.Range(-baseMomentum, baseMomentum);
    }

/// <summary>
/// 
/// </summary>
/// <param name="player"></param>
    // Reset the mini game for new game
    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0f;
        currentMomentum = 0f;
        spak.rectTransform.rotation = startRotation;
        completionText.text = completionCounter.ToString("#.0");
    }

/// <summary>
/// 
/// </summary>
    public void ResetUser()
    {
        stationUser = "";
    }

/// <summary>
/// 
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
/// 
/// </summary>
    void HandlePlayerInput()
    {
        if (stationUser == "")
            return;
        
        float horizontalAxis = 0;
        
        //if (Mathf.Abs(Input.GetAxis("Horizontal" + stationUser)) > .7f)
        horizontalAxis = Input.GetAxis("Horizontal" + stationUser);

        if (horizontalAxis < -.1f && (spak.rectTransform.rotation.eulerAngles.z < 90f || spak.rectTransform.rotation.eulerAngles.z > 200f))
        {
            currentMomentum = baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
        if (horizontalAxis > .1f && (spak.rectTransform.rotation.eulerAngles.z < 120f || spak.rectTransform.rotation.eulerAngles.z > 270f))
        {
            currentMomentum = -baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
    }

/// <summary>
/// 
/// </summary>
    void CheckCompletionCriteria()
    {
        // Check if the mini game is complete
        if(completionCounter >= completionTime)
        {
            completionText.text = "Done";
            StartCoroutine(CompleteMiniGame());
        }

        // Update progress if the lever is within green area
        if(spak.rectTransform.rotation.eulerAngles.z < minCompletionAngle || spak.rectTransform.rotation.eulerAngles.z > maxCompletionAngle)
        {
            completionCounter += Time.deltaTime;
            completionText.text = completionCounter.ToString("#.0");
        }
    }

/// <summary>
/// 
/// </summary>
/// <returns></returns>
    IEnumerator CompleteMiniGame()
    {
        station.AddHealthToStation(completionValue);
        isComplete = true;
        stationUser = "";

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }

/// <summary>
/// 
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
        if(spak.rectTransform.rotation.eulerAngles.z < 90f || spak.rectTransform.rotation.eulerAngles.z > 270f)
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
    }
}
