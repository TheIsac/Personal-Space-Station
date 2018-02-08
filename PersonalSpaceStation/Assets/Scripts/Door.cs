using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator animator;
    bool doorOpen;
    bool doorOpenIdle;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.transform.parent.tag == "Player")
        {
            doorOpen = true;
            //DoorControl("Open");
        }
    }
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
