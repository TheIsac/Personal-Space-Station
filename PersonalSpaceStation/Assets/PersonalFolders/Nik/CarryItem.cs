using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItem : MonoBehaviour {

    public bool isBeingCarried = false;
    public BoxCollider boxCollider;

    private Transform originalParent;

	void Start () {
        originalParent = transform.parent;

    }
	
	void Update () {
		
	}

    public void PickUp(Transform carryPoint)
    {
        transform.position = carryPoint.position;
        transform.rotation = carryPoint.rotation;
        transform.SetParent(carryPoint);
        isBeingCarried = true;

        if(boxCollider != null)
            boxCollider.enabled = false;
    }

    public void Drop()
    {
        transform.SetParent(originalParent);
        isBeingCarried = false;

        if (boxCollider != null)
            boxCollider.enabled = true;
    }
}
