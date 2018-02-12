using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlurpState { Dead, Recharging, Unhappy}

[RequireComponent(typeof(FlurpMovement))]
public class Flurp : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public Sprite engineRoomIcon;
    public Sprite atmoRoomIcon;
    public Sprite plantRoomIcon;
    public Sprite pumpRoomIcon;

    public SpriteRenderer spriteRenderer;

    private FlurpState flurpState = FlurpState.Unhappy;

    private float lastTick;
    public float tickLength = 1f;

    float currentHappinessValue;
    float targetHappinessValue;
    float timerToReachNextStation = 20f;

    float baseTimeToReachHappiness = 20f;

    public TextMesh health;

    public bool canBeMoved;

    void Start()
    {
        lastTick = Time.time;
        currentStation = Station.WaterPumps;

        spriteRenderer.gameObject.SetActive(false);

        NewRandomRoom();
    }

    void Update()
    {
        Tick();
    }

    void NewRandomRoom()
    {
        do
        {
            targetStation = (Station)Random.Range(0, System.Enum.GetValues(typeof(Station)).Length - 1);
        }
        while (currentStation == targetStation);

        flurpState = FlurpState.Unhappy;

        currentHappinessValue = timerToReachNextStation;
        targetHappinessValue = timerToReachNextStation;

        health.text = currentHappinessValue.ToString();
        DisplayNewObjective();

        canBeMoved = true;
    }

    void DisplayNewObjective()
    {

        if (spriteRenderer == null)
            return;

        switch (targetStation)
        {
            case Station.EngineRoom:
                spriteRenderer.sprite = engineRoomIcon;
                break;
            case Station.AtmoRoom:
                spriteRenderer.sprite = atmoRoomIcon;
                break;
            case Station.PlantRoom:
                spriteRenderer.sprite = plantRoomIcon;
                break;
            case Station.WaterPumps:
                spriteRenderer.sprite = pumpRoomIcon;
                break;
            case Station.None:
                break;
            default:
                break;
        }

        spriteRenderer.gameObject.SetActive(true);
    }

    public void SetCurrentStation(Station station)
    {
        if (flurpState == FlurpState.Dead)
            return;

        currentStation = station;

        if(currentStation == targetStation && flurpState == FlurpState.Unhappy)
        {
            flurpState = FlurpState.Recharging;
            currentHappinessValue = 0f;
            targetHappinessValue = Mathf.RoundToInt(Random.Range(baseTimeToReachHappiness * .75f, baseTimeToReachHappiness * 1.25f));

            //canBeMoved = false;
            spriteRenderer.gameObject.SetActive(false);
        }
        else
        {
            DisplayNewObjective();
        }
    }

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
    }

    void WellBeeingControl()
    {
        if(currentStation == targetStation)
        {
            currentHappinessValue++;
        }
        else
        {
            currentHappinessValue--;
            DisplayNewObjective();
        }

        if(currentHappinessValue >= targetHappinessValue)
        {
            canBeMoved = true;
            NewRandomRoom();
        }

        if(currentHappinessValue <= 0)
        {
            EndGame();
        }

        health.text = currentHappinessValue.ToString();
    }
}
