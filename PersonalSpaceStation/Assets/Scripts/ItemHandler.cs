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

    private void Update()
    {
        if (movement == null)
            return;


        if(itemInRange || carriedItem)
        {
            PlayerInput();
        }
    }

    void PlayerInput()
    {
        if(carriedItem == null)
        {
            if (Input.GetButtonDown("A-button" + movement.player))
            {
                carriedItem = itemInRange;

                characterAnimator.SetBool("CarryingItem", true);
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
                carriedItem = null;
            }
        }






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
