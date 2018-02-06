using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlurpMovement : MonoBehaviour {

    Vector3 moveCircleOrigin;
    float moveRadius = 3f;
    Vector3 targetPosition;
    float moveSpeed = 1f;

    public bool shouldMove = true;

	void Start () {
        moveCircleOrigin = transform.position;
        targetPosition = moveCircleOrigin;
    }
	
	void Update () {
		if(shouldMove == true)
        {
            Vector3 directionToTarget = targetPosition - transform.position;
            if(directionToTarget.sqrMagnitude < .1f)
            {
                SetNewDestination();
                directionToTarget = targetPosition - transform.position;
            }


            directionToTarget.Normalize();

            transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        }
	}

    private void SetNewDestination()
    {
        targetPosition = moveCircleOrigin + Random.insideUnitSphere * moveRadius;
        targetPosition.y = 0f;
    }

    public void SetMoveArea()
    {
        moveCircleOrigin = transform.position;
        targetPosition = transform.position;
        shouldMove = true;
    }
}
