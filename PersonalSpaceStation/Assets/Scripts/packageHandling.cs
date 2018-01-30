using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packageHandling : MonoBehaviour
{

    public Interactable[] stations;
    private float lastTick;
    public float tickLength = 2f;
    public int addHealth = 1;

    // Use this for initialization
    void Start()
    {
        lastTick = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
        CheckStatus();

    }

    void Tick()
    {
        if (Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
        }
    }

    void CheckStatus()
    {
        for (int i = 0; i < stations.Length; i++)
        {
            if (stations[i].isWorking)
            {
                stations[(i + 1) % stations.Length].AddHealthToStation(addHealth);
            }
        }
        //Kolla av om stationen isWorking, om den är det så kan paketet passera vidare. Engine Room - Water Room, Water - Atmo, Atmo - Plant, Plant - Engine. 
        //Addera hälsa till stationen som är beroende av den om den nuvarande fungerar och kopplingen dem emellan fungerar. 
    }

}