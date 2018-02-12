using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandler : MonoBehaviour {

    private Interactable currentStation;
    ItemHandler itemHandler;
    Movement movement;
    Rigidbody playerRigidbody;

    public Animator anim;

    void Awake () {
        itemHandler = GetComponent<ItemHandler>();
        movement = GetComponent<Movement>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        HandleInteractionInput();

    }

    public void SetStation(Interactable station)
    {
        currentStation = station;
    }

    private void HandleInteractionInput()
    {
        // You shouldnt be able to interact with stations if you are carrying an item
        if(itemHandler != null)
        {
            if(itemHandler.IsCarryingItem())
            {
                return;
            }
        }

        // Check if there is a station to interact with
        if(currentStation == null)
        {
            return;
        }

        // Input

        if (Input.GetButtonDown("B-button" + movement.player) && currentStation.inUse == true && currentStation.stationUser == movement)
        {
            playerRigidbody.isKinematic = false;
            movement.inMiniGame = false;

            anim.SetBool("isInteracting", false);
            currentStation.EndMiniGame();
        }

        if (currentStation.locked)
            return;

        if (Input.GetButtonDown("A-button" + movement.player) && currentStation.inUse == false)
        {
            playerRigidbody.isKinematic = true;
            movement.inMiniGame = true;

            anim.SetBool("isInteracting", true);
            currentStation.StartMiniGame(movement);

        }
    }
}
