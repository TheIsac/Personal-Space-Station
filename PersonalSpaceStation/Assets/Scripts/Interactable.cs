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
    public int stationHealth = 50;
    public string stationName = "Engine Room";

    private DocGenerator docG;

    public Action OnStationFailure;
    public Action OnStationFixed;

    private float lastTick;
    public float tickLength = 2f;

    public int minWorkingHealth = 25;
    public int maxWorkingHealth = 75;

    private Movement stationUser = null;

    public Text healthText;

    void Start()
    {
        lastTick = Time.time;
        docG = GetComponent<DocGenerator>();
    }

    //only handle player input if the player is in range.
    void Update()
    {
        if (playerInRange)
        {
            HandlePlayerInput();
        }

        Tick();
    }

    //if the miniGame is complete the minigame exits and is completed. 
    public void MiniGameComplete()
    {
        inUse = false;
        miniGame.SetActive(false);

        if (stationUser != null)
        {
            stationUser.inMiniGame = false;


        // Doc gen
        if(docG != null)
        {
            docG.DocumentGenerator();
        }

            stationUser.GetComponent<Rigidbody>().isKinematic = false;
        }    

    }

    //gives health to the station if the station is repaired or the previous station works and sends health.
    public void AddHealthToStation(int healthToGive)
    {
        stationHealth += healthToGive;
        UpdateHealthDisplay();
    }

    //removes health from the station if the stations following the current one is overworked.
    public void RemoveHealthFromStation(int healthToRemove)
    {
        stationHealth -= healthToRemove;
        UpdateHealthDisplay();
    }

    //update the health text to reflect the stations current health.
    private void UpdateHealthDisplay()
    {
        healthText.text = stationHealth.ToString();
    }

    //removes health from the stations every other second,it also checks and updates the health at that same time. 
    void Tick()
    {
        if(Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            stationHealth-=2;

            UpdateHealthDisplay();
            CheckStationHealth();
        }
    }

    //Checks the stations health and either makes a station fail or get fixed depending on the station health and wether or not it is working
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
    //if the stations health goes under the minimunhealth or over the maximumhealth the station breaks an down. The action OnStationFailure exists and checks
    //if there is another script that cares if the station is working or not, if there isn't any script caring then this function is not run. 
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
    //If the station is fixed it is set to work again, and can again interact with other stations through the PackageHandler script.  The action OnStationFixed exists 
    //and checks if there is another script that cares if the station is working or not, if there isn't any script caring then this function is not run. 
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

    //if a player enters a collider the station is only assigned a "stationUser" if there was not already one. This is so that two players can't use the same station
    //and so that the same game doesn´t trigger twice for the same player. If a player enters and is not already a user, and there are no users, this function fetches
    //that players movement script so that it can use it's value for player.
    private void OnTriggerEnter(Collider other)
    {
        if (stationUser != null)
            return;


        playerInRange = true;
        stationUser = other.gameObject.GetComponentInParent<Movement>();
    }

    //when the player leaves the collider of the miniGame there is no longer a player in range nor is there a station user. 
    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        stationUser = null;
    }

    private void HandlePlayerInput()
    {
        //if there player has left the station area, there is no station user and this code should not run.
        if (stationUser == null)
            return;


        //When you press the button "A" different things happen depending on if the game is on or not. If the player is in the game, pressing "A" exits the game. If the player 
        //is not in the game, pressing "A" enters the game. 
        if(Input.GetButtonDown("A-button" + stationUser.player) && inUse == false)
        {
            inUse = true;
            miniGame.GetComponent<IResetStation>().ResetStation(stationUser.player);
            stationUser.GetComponent<Rigidbody>().isKinematic = true;
            miniGame.SetActive(true);
            stationUser.inMiniGame = true;
        }
        if (Input.GetButtonDown("B-button" + stationUser.player) && inUse == true)
        {
            inUse = false;
            miniGame.SetActive(false);
            miniGame.GetComponent<IResetUser>().ResetUser();
            stationUser.GetComponent<Rigidbody>().isKinematic = false;
            stationUser.inMiniGame = false;
        }
    }
}