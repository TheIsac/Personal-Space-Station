using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIHandler : MonoBehaviour {

    public Interactable engine, pump, atmo, plant;

    public Image aEngine, aPump, aAtmo, aPlant;
    public Image eEngine, ePump, eAtmo, ePlant;
    public Image docEngine, docPump, docAtmo, docPlant;
	
	void Update () {
        if (engine.locked)
        {
            aEngine.color = Color.clear;
            eEngine.color = Color.white;
            docEngine.color = Color.white;
        }
        else
        {
            aEngine.color = Color.white;
            eEngine.color = Color.clear;
            docEngine.color = Color.clear;
        }

        if (pump.locked)
        {
            aPump.color = Color.clear;
            ePump.color = Color.white;
            docPump.color = Color.white;
        }
        else
        {
            aPump.color = Color.white;
            ePump.color = Color.clear;
            docPump.color = Color.clear;
        }

        if (atmo.locked)
        {
            aAtmo.color = Color.clear;
            eAtmo.color = Color.white;
            docAtmo.color = Color.white;
        }
        else
        {
            aAtmo.color = Color.white;
            eAtmo.color = Color.clear;
            docAtmo.color = Color.clear;
        }

        if (plant.locked)
        {
            aPlant.color = Color.clear;
            ePlant.color = Color.white;
            docPlant.color = Color.white;
        }
        else
        {
            aPlant.color = Color.white;
            ePlant.color = Color.clear;
            docPlant.color = Color.clear;
        }
    }
}
