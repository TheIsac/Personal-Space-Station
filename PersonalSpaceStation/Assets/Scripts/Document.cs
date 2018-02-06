using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public Action HandIn;


    public void SetDestinationStation(Station targetStation)
    {
        this.targetStation = targetStation;
    }

    public void DeliverDocument()
    {
        HandIn.Invoke();
        Destroy(gameObject);
    }
}
