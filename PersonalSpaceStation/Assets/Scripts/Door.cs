using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator animator;
    bool doorOpen;
    bool doorOpenIdle;
    //door is closed at the start of the game.
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }
    //if the object with the tag "Player" enters the trigger then it will play the animation "doorOpen".
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.transform.parent.tag == "Player")
        {
            doorOpen = true;
            //DoorControl("Open");
        }
    }
    //if you stay inside the trigger zone it will play the "openIdle" animation and lets the door stay open.
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.transform.parent.tag == "Player")
        {
            doorOpenIdle = true;
            animator.SetBool("IsOpen", true);
        }
        else
        {
            doorOpenIdle = false;
            animator.SetBool("IsOpen", false);
        }
    }
    //if the player exits the trigger zone it will close the door.
    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;

            //DoorControl("Close");
        }
        animator.SetBool("IsOpen", false);
    }

    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
    }

}
