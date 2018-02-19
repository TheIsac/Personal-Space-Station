using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItem : MonoBehaviour {

    //the different variables and gameObjects required for Flurp.
    public bool isBeingCarried = false;
    public Collider physicsCollider;
    private Rigidbody myRigidBody;

    private Transform originalParent;
    FlurpMovement flurpMovement;

    //sets the original parent.
    void Start ()
    {
        originalParent = transform.parent;

        myRigidBody = GetComponent<Rigidbody>();
        flurpMovement = GetComponent<FlurpMovement>();
    }
	
	void Update ()
    {
		
	}

    /// <summary>
    /// the method for picking up flurp. If zhe is picked up zhe won't move and zhes rotation and position is changed to the carrying players
    /// rotation and position. And the bool isBeingCarried is set as true. 
    /// </summary>
    /// <param name="carryPoint"></param>
    public void PickUp(Transform carryPoint)
    {
        if (flurpMovement != null)
        {
            //Debug.Log(flurpMovement.GetComponent<Flurp>().canBeMoved);

            //if (flurpMovement.GetComponent<Flurp>().canBeMoved == false)
            //    return;

            flurpMovement.shouldMove = false;
        }

        transform.position = carryPoint.position;
        transform.rotation = carryPoint.rotation;
        transform.SetParent(carryPoint);
        isBeingCarried = true;

        if(myRigidBody != null)
        {
            myRigidBody.isKinematic = true;
        }

        if(physicsCollider != null)
            physicsCollider.enabled = false;

        AudioManager.instance.Play("Pickup");
    }

    /// <summary>
    /// the method for dropping Flurp, the bool isBeingCarried is set as false and zhe can move again. And the drop sound is played. 
    /// </summary>
    public void Drop()
    {
        transform.SetParent(originalParent);
        isBeingCarried = false;

        if (myRigidBody != null)
        {
            myRigidBody.isKinematic = false;
        }

        if (physicsCollider != null)
            physicsCollider.enabled = true;

        if (flurpMovement != null)
        {
            flurpMovement.SetMoveArea();
        }
        AudioManager.instance.Play("Drop");
    }
}
