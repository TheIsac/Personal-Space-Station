﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlurpMovement : MonoBehaviour {

    Vector3 moveCircleOrigin;
    Vector3 targetPosition;

    Rigidbody flurpRigidBody;

    float moveSpeed = 1f;
    float moveRadius = 3f;

    public bool shouldMove = true;

    private void Awake()
    {
        flurpRigidBody = GetComponent<Rigidbody>();
    }

    void Start () {
        moveCircleOrigin = transform.position;
        targetPosition = moveCircleOrigin;
    }
	
	void FixedUpdate () {

		if(shouldMove == true)
        {
            Vector3 directionToTarget = targetPosition - transform.position;

            if (directionToTarget.sqrMagnitude < .1f || flurpRigidBody.velocity.sqrMagnitude < .01f)
            {
                SetNewDestination();
                directionToTarget = targetPosition - transform.position;
            }


            directionToTarget.Normalize();

            flurpRigidBody.velocity = directionToTarget * moveSpeed;

            //transform.position += directionToTarget * moveSpeed * Time.deltaTime;

            //if (lastPosition == transform.position)
            //{
            //    SetNewDestination();
            //}

        }
        else
        {
            flurpRigidBody.velocity = Vector3.zero;
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