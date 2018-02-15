using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {

    //public bool itemInRange = false;
    private Movement movement;
    CarryItem carriedItem = null;
    CarryItem itemInRange = null;
    private Animator characterAnimator;

    public Transform carryPoint;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        characterAnimator = GetComponentInChildren<Animator>();
    }

    public bool IsCarryingItem()
    {
        return carriedItem != null;
    }

    private void Update()
    {
        if (GameManager.instance == null)
            return;

        if (GameManager.instance.gameIsPaused == true)
        {
            return;
        }
        else
        {
            if (movement == null)
                return;


            if(itemInRange || carriedItem)
            {
                PlayerInput();
            }
        }
    }

    public void onHandIn()
    {
        carriedItem = null;
        characterAnimator.SetBool("CarryingItem", false);
    }

    void PlayerInput()
    {
        if (movement.inMiniGame)
            return;

        // Only allow for item pickup if you aren't already carrying an item
        if(carriedItem == null)
        {
            if (Input.GetButtonDown("A-button" + movement.player))
            {
                carriedItem = itemInRange;
                characterAnimator.SetBool("CarryingItem", true);

                Document doc = carriedItem.GetComponent<Document>();

                if(doc != null)
                {
                    doc.HandIn += onHandIn;
                }

                // If the object picking up an item has a defined carry transform, use it, otherwise spawn the item at its location
                if (carryPoint != null)
                    carriedItem.PickUp(carryPoint);
                else
                    carriedItem.PickUp(transform);
            }
        }
        else
        {
            if (Input.GetButtonDown("A-button" + movement.player))
            {
                characterAnimator.SetBool("CarryingItem", false);
                carriedItem.Drop();
                itemInRange = carriedItem;
                StartCoroutine(Drop());
            }
        }
    }

    // Wait until the end of fram to update that the player no longer carries an item so it wont trigger a station if you drop the item close to it
    IEnumerator Drop()
    {
        yield return new WaitForEndOfFrame();
        carriedItem = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        CarryItem tempItem = other.GetComponent<CarryItem>();

        if (tempItem != null)
        {
            itemInRange = tempItem;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CarryItem tempItem = other.GetComponent<CarryItem>();

        if (tempItem != null)
        {
            itemInRange = null;
        }
    }

    //public void SetItemInRange(bool inRange)
    //{
    //    itemInRange = inRange;
    //}
}
