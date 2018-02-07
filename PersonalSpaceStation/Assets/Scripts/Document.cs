using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public Action HandIn;

    Material documentMaterial;

    public void SetDestinationStation(Station destinationStation)
    {
        this.targetStation = destinationStation;
        Debug.Log(targetStation);

        documentMaterial = GetComponent<Renderer>().material;

        switch (targetStation)
        {
            case Station.EngineRoom:
                documentMaterial.color = Color.red;
                break;
            case Station.AtmoRoom:
                documentMaterial.color = Color.yellow;
                break;
            case Station.PlantRoom:
                documentMaterial.color = Color.green;
                break;
            case Station.WaterPumps:
                documentMaterial.color = Color.blue;
                break;
            default:
                documentMaterial.color = Color.black;
                break;
        }
    }

    public void DeliverDocument()
    {
        HandIn.Invoke();
        Destroy(gameObject);
    }
}
