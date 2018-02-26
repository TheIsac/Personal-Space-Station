using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStation : MonoBehaviour {

    //when the player leaves the collider of the miniGame there is no longer a player in range nor is there a station user. 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<InteractableHandler>().SetStation(null);
        }
    }
}
