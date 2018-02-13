using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPointBroken : MonoBehaviour {

    public FixPointChecker plantEngine, atmoPlant, pumpAtmo, enginePump;
    public GameObject goPlantEngine, goAtmoPlant, goPumpAtmo, goEnginePump;
	
	// Update is called once per frame
	void Update () {
        if (plantEngine.repaired)
        {
            goPlantEngine.SetActive(false);
        }
        else
        {
            goPlantEngine.SetActive(true);
        }

        if (atmoPlant.repaired)
        {
            goAtmoPlant.SetActive(false);
        }
        else
        {
            goAtmoPlant.SetActive(true);
        }

        if (pumpAtmo.repaired)
        {
            goPumpAtmo.SetActive(false);
        }
        else
        {
            goPumpAtmo.SetActive(true);
        }

        if (enginePump.repaired)
        {
            goEnginePump.SetActive(false);
        }
        else
        {
            goEnginePump.SetActive(true);
        }
    }
}
