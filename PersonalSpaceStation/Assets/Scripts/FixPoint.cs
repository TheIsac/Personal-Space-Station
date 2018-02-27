using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPoint : MonoBehaviour {

    public GameObject icon;

    private bool playerInRange;
    private bool stationed;
    private bool pressed;

    private int isPressed;

    private Movement stationUser = null;
    private FixPointChecker fixPointChecker;

    private void Awake()
    {
        fixPointChecker = GetComponentInParent<FixPointChecker>();
    }

    void WhichPoint()
    {
        if (name == "FirstPoint")
        {
            fixPointChecker.stationedFirst = stationed;
            fixPointChecker.pressedFirst = pressed;
        }
        else if (name == "SecondPoint")
        {
            fixPointChecker.stationedSecond = stationed;
            fixPointChecker.pressedSecond = pressed;
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

        if (Input.GetButton("X-button" + stationUser.player))
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
        if(icon != null && !fixPointChecker.repaired)
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        stationUser = null;
        stationed = false;
        pressed = false;
        if (icon != null)
        {
            icon.SetActive(false);
        }
    }

    public void OnDrawGizmos()
    {
        Collider pointCollider = GetComponent<Collider>();
        Vector3 pointCenter = pointCollider.bounds.center;
        Vector3 pointSize = pointCollider.bounds.size;


        if (name == "FirstPoint")
        {
        Gizmos.color = new Color(1, 0.5f, 0, 0.7f);
        Gizmos.DrawCube(pointCenter, pointSize);
        }
        else if (name == "SecondPoint")
        {
            Gizmos.color = new Color(0, 1, 1, 0.7f);
            Gizmos.DrawCube(pointCenter, pointSize);
            GetComponent<Collider>();
        }
    }
}