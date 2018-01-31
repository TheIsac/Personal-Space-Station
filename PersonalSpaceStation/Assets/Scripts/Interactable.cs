using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public GameObject miniGame;
    public bool inUse = false;
    private bool playerInRange = false;
    public bool isWorking;
    private int stationHealth = 50;
    public string stationName = "Engine Room";

    public Action OnStationFailure;
    public Action OnStationFixed;

    private float lastTick;
    public float tickLength = 2f;

    public int minWorkingHealth = 25;
    public int maxWorkingHealth = 75;

    private MovementNik stationUser = null;

    public Text healthText;

    void Start()
    {
        lastTick = Time.time;
    }

    void Update()
    {
        if (playerInRange)
        {
            HandlePlayerInput();
        }

        Tick();
    }

    public void MiniGameComplete()
    {
        miniGame.SetActive(false);

        if (stationUser != null)
            stationUser.inMiniGame = false;
    }

    public void AddHealthToStation(int healthToGive)
    {
        stationHealth += healthToGive;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        healthText.text = stationHealth.ToString();
    }

    void Tick()
    {
        if(Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            stationHealth--;

            UpdateHealthDisplay();
            CheckStationHealth();
        }
    }

    void CheckStationHealth()
    {
        if ((stationHealth < minWorkingHealth || stationHealth > maxWorkingHealth) && isWorking)
        {
            StationFailure();
        }

        if (stationHealth <= maxWorkingHealth && stationHealth >= minWorkingHealth && !isWorking)
        {
            StationFixed();
        }
    }

    void StationFailure()
    {
        Debug.Log("ZOMG ENGINE BORKED!");
        isWorking = false;

        if (OnStationFailure != null)
        {
            OnStationFailure.Invoke();
        }

        healthText.color = Color.red;
    }

    void StationFixed()
    {
        Debug.Log("LOL FIXERD");
        isWorking = true;

        if (OnStationFixed != null)
        {
            OnStationFixed.Invoke();
        }

        healthText.color = Color.black;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stationUser != null)
            return;


        playerInRange = true;
        stationUser = other.gameObject.GetComponent<MovementNik>();
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        stationUser = null;
    }

    private void HandlePlayerInput()
    {
        if (stationUser == null)
            return;


        if(Input.GetButtonDown("A-button" + stationUser.player))
        {
            if (inUse)
            {
                inUse = false;
                miniGame.SetActive(false);
                miniGame.GetComponent<IResetUser>().ResetUser();
                stationUser.inMiniGame = false;
            }
            else
            {
                inUse = true;
                miniGame.SetActive(true);
                miniGame.GetComponent<IResetStation>().ResetStation(stationUser.player);
                stationUser.inMiniGame = true;
            }
        }
    }
}