using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public GameObject miniGame;
    public bool inUse = false;
    public bool locked = false;
    //private bool playerInRange = false;
    public bool isWorking;
    public int stationHealth = 50;
    public string stationName = "Engine Room";

    public DocGenerator documentGenerator;

    public Action OnStationFailure;
    public Action OnStationFixed;

    private float lastTick;
    //public float tickLength = 2f;

    public int minWorkingHealth = 25;
    public int maxWorkingHealth = 10000;

    public Movement stationUser = null;

    public Text healthText;

    void Start()
    {
        lastTick = Time.time;
    }

    void Update()
    {
        Tick();

        if (locked)
        {
            return;
        }
    }

    //if the miniGame is complete the minigame exits and is completed. 
    public void MiniGameComplete()
    {
        if (stationUser!= null)
        {
            Animator anim = stationUser.GetComponentInChildren<Animator>();

            if (anim != null)
            {
                anim.SetBool("isInteracting", false);
            }

            stationUser.inMiniGame = false;
            stationUser.GetComponent<Rigidbody>().isKinematic = false;

            // Doc gen
            if (documentGenerator != null)
            {
                documentGenerator.DocumentGenerator();
            }
        }

        StartCoroutine(CompleteMiniGame());
    }

    IEnumerator CompleteMiniGame()
    {
        yield return new WaitForSeconds(.5f);
        miniGame.SetActive(false);
        inUse = false;
    }

    public void StartMiniGame(Movement playerMovement)
    {
        inUse = true;
        miniGame.GetComponent<IResetStation>().ResetStation(playerMovement.player);
        miniGame.SetActive(true);

        stationUser = playerMovement;
    }

    public void EndMiniGame()
    {
        inUse = false;
        miniGame.SetActive(false);
        miniGame.GetComponent<IResetUser>().ResetUser();

        stationUser = null;
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
        if(Time.time - lastTick > GameManager.instance.stationTickLength)
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
        isWorking = true;

        if (OnStationFixed != null)
        {
            OnStationFixed.Invoke();
        }

        healthText.color = Color.black;
    }
}