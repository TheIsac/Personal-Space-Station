using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterStation : MonoBehaviour {

    public Interactable station;

    // Tell the player which station it is in range of
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<InteractableHandler>().SetStation(station);
        }
    }
}
