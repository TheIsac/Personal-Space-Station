using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointChecker : MonoBehaviour {

    public bool stationedFirst;
    public bool stationedSecond;

    public bool pressedFirst;
    public bool pressedSecond;

    public bool repaired;
	
	void Update () {

        if (stationedFirst &&
            stationedSecond &&
            pressedFirst &&
            pressedSecond)
        {
            repaired = true;
        }

	}
}