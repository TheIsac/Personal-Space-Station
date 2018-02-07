using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointChecker : MonoBehaviour {

    public bool stationedFirst;
    public bool stationedSecond;

    public bool pressedFirst;
    public bool pressedSecond;

    public bool repaired;

    private Light light;

    public float counter;

    private void Start()
    {
        repaired = true;
        counter = UnityEngine.Random.Range(0, 50);
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

        if(counter > 100)
        {
            repaired = false;
        }
        if(counter > 100 && repaired)
        {
            counter = UnityEngine.Random.Range(0, 50);
        }
    }
}