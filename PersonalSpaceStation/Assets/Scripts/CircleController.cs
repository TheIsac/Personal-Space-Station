using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour {

    public Interactable myStation;
    public GameObject myCircle;

    private void Update()
    {
        StationCheck();
    }

    void StationCheck()
    {
        if (myStation.locked)
        {
            myCircle.SetActive(false);
        }
        if (!myStation.locked)
        {
            myCircle.SetActive(true);
        }
    }
}
