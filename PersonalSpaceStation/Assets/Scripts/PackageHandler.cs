using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageHandler : MonoBehaviour
{
    //An array that you have to add every individual interactable object to in the inspector.
    private float lastTick;
    public float tickLength = 2f;
    public int addHealth = 1;
    public int removeHealth = 1;
    //private int overChargeValue = 60;

    public Interactable[] stations;
    public FixPointChecker[] fixPoint;

    // Use this for initialization
    void Start()
    {
        //counts the time.
        lastTick = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
    }

    void Tick()
    {
        if (Time.time - lastTick > GameManager.instance.stationTickLength)
        {
            lastTick = Time.time;
            CheckStatus();
        }
    }

    void CheckStatus()
    {
        //go through every station, if it is active send some health to the station that comes after it. 
        for (int i = 0; i < stations.Length; i++)
        {
            if (stations[i].isWorking)
            {
                addHealth = 1;

                if (!fixPoint[i].repaired)
                {
                    addHealth = 0;
                }
                stations[(i + 1) % stations.Length].AddHealthToStation(addHealth);
            }
            if (stations[i].isWorking && stations[i].stationHealth > GameManager.instance.overloadThreshhold)
            {
                stations[((i - 1 + stations.Length) % stations.Length)].RemoveHealthFromStation(removeHealth);

            }
        }
        //Kolla av om stationen isWorking, om den är det så kan paketet passera vidare. Engine Room - Water Room, Water - Atmo, Atmo - Plant, Plant - Engine. 
        //Addera hälsa till stationen som är beroende av den om den nuvarande fungerar och kopplingen dem emellan fungerar. 
    }

}