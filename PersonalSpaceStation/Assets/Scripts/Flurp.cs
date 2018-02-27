using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FlurpState { Dead, Recharging, Unhappy}

[RequireComponent(typeof(FlurpMovement))]
public class Flurp : MonoBehaviour {

    [Header("Station Control")]
    public Station currentStation;
    public Station targetStation;
    //public bool canBeMoved;

    [Header("Graphics")]
    public Sprite engineRoomIcon;
    public Sprite atmoRoomIcon;
    public Sprite plantRoomIcon;
    public Sprite pumpRoomIcon;

    public Image targetRoomSpriteUI;
    public Image speechBubbleSpriteUI;

    public Sprite rechargingSpeechBubble;
    public Sprite unhappySpeechBubble;

    public Sprite rechargingSpeechBubbleUI;
    public Sprite unhappySpeechBubbleUI;

    public SpriteRenderer targetRoomSprite;
    public SpriteRenderer speechBubbleSprite;

    public Animator flurpUI;
    public Animator flurpPopup;

    [Header("Settings")]
    public float timerToReachNextStation = 20f;
    public float baseTimeToReachHappiness = 25f;
    public float tickLength = 1f;
    public TextMesh health;

    public FlurpState flurpState = FlurpState.Unhappy;
    private float lastTick;

    float currentHappinessValue;
    float targetHappinessValue;
    float timeToReachTarget;


    void Start()
    {
        lastTick = Time.time;
        targetRoomSpriteUI.gameObject.SetActive(false);
        speechBubbleSpriteUI.gameObject.SetActive(false);

        targetRoomSprite.gameObject.SetActive(false);
        speechBubbleSprite.gameObject.SetActive(false);

        NewRandomRoom();
    }

    void Update()
    {
        Tick();
    }

    void NewRandomRoom()
    {
        // Pick a new room randomly amongst the rooms flurp isn't currently in
        do
        {
            targetStation = (Station)Random.Range(0, System.Enum.GetValues(typeof(Station)).Length - 1);
        }
        while (currentStation == targetStation);

        flurpState = FlurpState.Unhappy;

        timeToReachTarget = timerToReachNextStation;
        //targetHappinessValue = timerToReachNextStation;

        health.text = currentHappinessValue.ToString();
        DisplayNewObjective();


        StartCoroutine(FlashNewObjective());
        //canBeMoved = true;
    }

    IEnumerator FlashNewObjective()
    {
        flurpUI.SetBool("Flashing", true);
        flurpPopup.SetBool("Flashing", true);

        yield return new WaitForSeconds(.5f);

        flurpUI.SetBool("Flashing", false);
        flurpPopup.SetBool("Flashing", false);
    }

    void DisplayNewObjective()
    {

        if (targetRoomSpriteUI == null)
            return;

        switch (targetStation)
        {
            case Station.EngineRoom:
                targetRoomSpriteUI.sprite = engineRoomIcon;
                targetRoomSprite.sprite = engineRoomIcon;
                break;
            case Station.AtmoRoom:
                targetRoomSpriteUI.sprite = atmoRoomIcon;
                targetRoomSprite.sprite = atmoRoomIcon;
                break;
            case Station.PlantRoom:
                targetRoomSpriteUI.sprite = plantRoomIcon;
                targetRoomSprite.sprite = plantRoomIcon;
                break;
            case Station.WaterPumps:
                targetRoomSpriteUI.sprite = pumpRoomIcon;
                targetRoomSprite.sprite = pumpRoomIcon;
                break;
            case Station.None:
                break;
            default:
                break;
        }

        targetRoomSpriteUI.gameObject.SetActive(true);
        speechBubbleSpriteUI.gameObject.SetActive(true);

        targetRoomSprite.gameObject.SetActive(true);
        speechBubbleSprite.gameObject.SetActive(true);

        speechBubbleSprite.sprite = unhappySpeechBubble;
        speechBubbleSpriteUI.sprite = unhappySpeechBubbleUI;
    }

    public void SetCurrentStation(Station station)
    {
        if (flurpState == FlurpState.Dead)
            return;

        currentStation = station;

        if(currentStation == targetStation && flurpState == FlurpState.Unhappy)
        {
            flurpState = FlurpState.Recharging;
            currentHappinessValue = 5f;
            targetHappinessValue = Mathf.RoundToInt(Random.Range(baseTimeToReachHappiness * .75f, baseTimeToReachHappiness * 1.25f));

            flurpUI.SetBool("Flashing", false);
            flurpPopup.SetBool("Flashing", false);

            //targetRoomSpriteUI.gameObject.SetActive(false);
            //speechBubbleSpriteUI.gameObject.SetActive(false);

            targetRoomSprite.gameObject.SetActive(false);
            speechBubbleSprite.gameObject.SetActive(false);

            speechBubbleSprite.sprite = rechargingSpeechBubble;
            speechBubbleSpriteUI.sprite = rechargingSpeechBubbleUI;

            speechBubbleSpriteUI.fillAmount = Mathf.Lerp(0f, 1f, currentHappinessValue / targetHappinessValue);
        }
        else if(currentStation == targetStation && flurpState == FlurpState.Recharging)
        {
            //targetRoomSpriteUI.gameObject.SetActive(false);
            //speechBubbleSpriteUI.gameObject.SetActive(false);

            targetRoomSprite.gameObject.SetActive(false);
            speechBubbleSprite.gameObject.SetActive(false);

            speechBubbleSprite.sprite = rechargingSpeechBubble;
            speechBubbleSpriteUI.sprite = rechargingSpeechBubbleUI;

        }
        else
        {
            DisplayNewObjective();
        }
    }

    // Only do the operations at set intervals
    void Tick()
    {
        if (Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            WellBeeingControl(); 
        }
    }

    void EndGame()
    {
        flurpState = FlurpState.Dead;

        GameManager.instance.GameOver();
    }

    // Update Flurps current happiness and take appropriate action
    void WellBeeingControl()
    {
        speechBubbleSpriteUI.fillAmount = 1;

        if (flurpState == FlurpState.Unhappy)
        {
            timeToReachTarget -= tickLength;

            // fill amount
            speechBubbleSpriteUI.fillAmount = Mathf.Lerp(0f, 1f, timeToReachTarget / timerToReachNextStation);

            if (timeToReachTarget <= 0)
            {
                EndGame();
            }

            if(timeToReachTarget <= 10)
            {
                flurpUI.SetBool("Flashing", true);
                flurpPopup.SetBool("Flashing", true);
            }
        }

        if(currentStation == targetStation)
        {
            currentHappinessValue++;
        }
        else
        {
            currentHappinessValue--;
            DisplayNewObjective();
        }

        if (flurpState == FlurpState.Recharging)
        {
            speechBubbleSpriteUI.fillAmount = Mathf.Lerp(0f, 1f, currentHappinessValue / targetHappinessValue);
        }


        if (currentHappinessValue >= targetHappinessValue)
        {
            //canBeMoved = true;
            NewRandomRoom();
        }

        if(currentHappinessValue <= 0 && flurpState == FlurpState.Recharging)
        {
            EndGame();
        }

        health.text = currentHappinessValue.ToString();
    }
}
