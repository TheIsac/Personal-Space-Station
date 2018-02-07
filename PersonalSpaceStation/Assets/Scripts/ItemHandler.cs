using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {

    //public bool itemInRange = false;
    private Movement movement;
    CarryItem carriedItem = null;
    CarryItem itemInRange = null;

    public Transform carryPoint;

    private void Awake()
    {
        movement = GetComponent<Movement>();
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
