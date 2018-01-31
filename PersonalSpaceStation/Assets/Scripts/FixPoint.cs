using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPoint : MonoBehaviour {

    public bool playerInRange;
    public bool firstPoint;
    public bool secondPoint;

    private bool stationedFirst;
    private bool stationedSecond;

    private bool pressedFirst;
    private bool pressedSecond;

    private Movement stationUser = null;
    private int isPressed;

    private void Start()
    {
        WhichPoint();
    }

    void WhichPoint()
    {
        if (firstPoint)
        {

        }
        else if (secondPoint)
        {

        }
    }

    private void Update()
    {
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
            isPressed += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        stationUser = other.GetComponentInParent<Movement>();
        GetComponentInParent<FixPointChecker>().stationedFirst = true;
        isPressed = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        stationUser = null;
        //GetComponentInParent<FixPointChecker>().stationed = false;
        isPressed = 0;

    }
}