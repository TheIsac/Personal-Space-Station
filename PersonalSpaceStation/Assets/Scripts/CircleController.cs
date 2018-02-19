using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour {

    public Interactable myStation;

    private void Update()
    {
        StationCheck();
    }

    void StationCheck()
    {
        if (myStation.locked)
        {
            gameObject.SetActive(false);
        }
        if (!myStation.locked)
        {
            gameObject.SetActive(true);
        }
    }
}
