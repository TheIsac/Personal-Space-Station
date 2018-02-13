using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItem : MonoBehaviour {

    public bool isBeingCarried = false;
    public Collider physicsCollider;
    private Rigidbody myRigidBody;

    private Transform originalParent;
    FlurpMovement flurpMovement;


    void Start () {
        originalParent = transform.parent;

        myRigidBody = GetComponent<Rigidbody>();
        flurpMovement = GetComponent<FlurpMovement>();
    }
	
	void Update () {
		
	}

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
