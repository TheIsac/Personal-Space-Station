using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointChecker : MonoBehaviour {

    public bool stationedFirst;
    public bool stationedSecond;

    public bool pressedFirst;
    public bool pressedSecond;

    public Station sendingStation;
    public Station recievingStation;

    public bool repaired;

    private Light light;

    public float counter;

    private float target;

    private void Start()
    {
        target = UnityEngine.Random.Range(75, 150);
        repaired = true;
        light = GetComponent<Light>();
    }

    void Update () {
        
        if (stationedFirst &&
            stationedSecond &&
            pressedFirst &&
            pressedSecond)
        {
            repaired = true;
        }

        if(repaired)
        {
            light.intensity = 0;
        }
        else
        {
            light.intensity = 4.7f;
        }

        TimeCounter();
	}

    private void TimeCounter()
    {
        counter += Time.deltaTime;

        if(counter > target && repaired)
        {
            target += UnityEngine.Random.Range(75, 150);
            repaired = false;
        }
    }
}