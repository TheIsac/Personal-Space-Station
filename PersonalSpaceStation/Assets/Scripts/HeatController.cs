using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Station { EngineRoom, AtmoRoom, PlantRoom, WaterPumps, None}
public class HeatController : MonoBehaviour
{
    public int currentHeatValue;
    public Station currentStation;

    private float lastTick;
    public float tickLength = 1f;

    const int MAX_HEAT = 100;

    void Start()
    {
        currentHeatValue = 0;
        lastTick = Time.time;
        currentStation = Station.None;
    }

    void Update()
    {
        Tick();
    }

    public void SetCurrentStation(Station station)
    {
        currentStation = station;
    }

    void Tick()
    {
        if (Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            HeatControl();
        }
    }

    void HeatControl()
    {
        if(currentStation == Station.EngineRoom)
        {
            currentHeatValue++;
            currentHeatValue = Mathf.Clamp(currentHeatValue, 0, MAX_HEAT);
        }
        else
        {
            currentHeatValue--;
            currentHeatValue = Mathf.Clamp(currentHeatValue, 0, MAX_HEAT);
        }
    }
}
