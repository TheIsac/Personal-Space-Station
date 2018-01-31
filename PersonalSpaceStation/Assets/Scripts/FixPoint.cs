using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPoint : MonoBehaviour {

    private bool playerInRange;

    private bool stationed;
    private bool pressed;

    private Movement stationUser = null;
    private int isPressed;

    void WhichPoint()
    {
        if (name == "FirstPoint")
        {
            GetComponentInParent<FixPointChecker>().stationedFirst = stationed;
            GetComponentInParent<FixPointChecker>().pressedFirst = pressed;
        }
        else if (name == "SecondPoint")
        {
            GetComponentInParent<FixPointChecker>().stationedSecond = stationed;
            GetComponentInParent<FixPointChecker>().pressedSecond = pressed;
        }
        else
        {
            Debug.LogError("DO NOT CHANGE FIXPOINT NAMES");
        }
    }

    private void Update()
    {
        WhichPoint();

        if (stationUser != null)
            print(stationUser.player);

        if (playerInRange)
        {
            CheckPlayerInput();
        }


    }

    void CheckPlayerInput()
    {
        if (stationUser == null)
            return;

        if (Input.GetButton("A-button" + stationUser.player))
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        stationUser = other.GetComponentInParent<Movement>();
        stationed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        stationUser = null;
        stationed = false;
        pressed = false;
    }
}