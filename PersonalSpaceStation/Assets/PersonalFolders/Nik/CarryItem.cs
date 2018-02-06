using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItem : MonoBehaviour {

    public bool isBeingCarried = false;
    public Collider physicsCollider;
    private Rigidbody myRigidBody;

    private Transform originalParent;

	void Start () {
        originalParent = transform.parent;
        myRigidBody = GetComponent<Rigidbody>();
    }
	
	void Update () {
		
	}

    public void PickUp(Transform carryPoint)
    {
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
    }
}
