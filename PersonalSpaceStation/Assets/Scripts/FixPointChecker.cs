using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointChecker : MonoBehaviour
{

    public bool stationedFirst;
    public bool stationedSecond;

    public bool pressedFirst;
    public bool pressedSecond;

    public Station sendingStation;
    public Station recievingStation;

    public bool repaired;

    private Light light;
    public GameObject repairSquare1, repairSquare2;

    public float counter;

    private float target;

    private void Start()
    {
        target = UnityEngine.Random.Range(75, 150);
        repaired = true;
        light = GetComponent<Light>();

        ToggleSquares(true);
    }

    void Update()
    {

        if (stationedFirst &&
            stationedSecond &&
            pressedFirst &&
            pressedSecond)
        {
            repaired = true;
        }

        if (repaired)
        {
            light.intensity = 0;
            ToggleSquares(false);
        }
        else
        {
            light.intensity = 4.7f;
            ToggleSquares(true);
        }

        TimeCounter();
    }

    private void TimeCounter()
    {
        counter += Time.deltaTime;

        if (counter > target && repaired)
        {
            target += UnityEngine.Random.Range(75, 150);
            repaired = false;
        }
    }

    private void ToggleSquares(bool repaired)
    {
        if (repairSquare1 == null || repairSquare2 == null)
            return;

        if (this.repaired)
        {
            repairSquare1.SetActive(false);
            repairSquare2.SetActive(false);
        }
        else
        {
            repairSquare1.SetActive(true);
            repairSquare2.SetActive(true);
        }
    }
}