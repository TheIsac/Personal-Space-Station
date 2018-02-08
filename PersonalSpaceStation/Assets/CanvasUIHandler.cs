using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIHandler : MonoBehaviour {

    public GameObject engine, pump, atmo, plant;

    public Image aEngine, aPump, aAtmo, aPlant;
    public Image eEngine, ePump, eAtmo, ePlant;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (engine.GetComponent<Interactable>().locked)
        {
            aEngine.color = Color.clear;
            eEngine.color = Color.white;
        }
        else
        {
            aEngine.color = Color.white;
            eEngine.color = Color.clear;
        }

        if (pump.GetComponent<Interactable>().locked)
        {
            aPump.color = Color.clear;
            ePump.color = Color.white;
        }
        else
        {
            aPump.color = Color.white;
            ePump.color = Color.clear;
        }

        if (atmo.GetComponent<Interactable>().locked)
        {
            aAtmo.color = Color.clear;
            eAtmo.color = Color.white;
        }
        else
        {
            aAtmo.color = Color.white;
            eAtmo.color = Color.clear;
        }

        if (plant.GetComponent<Interactable>().locked)
        {
            aPlant.color = Color.clear;
            ePlant.color = Color.white;
        }
        else
        {
            aPlant.color = Color.white;
            ePlant.color = Color.clear;
        }
    }
}
