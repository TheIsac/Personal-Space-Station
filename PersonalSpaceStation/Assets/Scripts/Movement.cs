using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Variables
    private float horizontalAxis;
    private float verticalAxis;
    //defined in the inspector of every character object.
    public float moveSpeed;

    public string player;
   
    private Vector3 movementDirection;
    private Vector3 lastMovement;

    public bool inMiniGame;

    Rigidbody playerRigidBody;

    private float maxHeight;

    // Use this for initialization
    void Start()
    {
        maxHeight = transform.position.y;
        playerRigidBody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //only move if the character isn't in a minigame, we don't want the player to run away from the game by mistake. 
        //the string player is defined in the inspector in unity, and in the input manager in unity there are one horizontal/vertical input for each player. 
        if (!inMiniGame)
        {
            horizontalAxis = Input.GetAxis("Horizontal" + player);
            verticalAxis = Input.GetAxis("Vertical" + player);


            CharacterMovement();
        }
        else 
        {
            playerRigidBody.velocity = Vector3.zero;
        }

        RestrictHeight();
    }

    public void CharacterMovement()
    {
        //move the character using the input from the individual axises, and transform the position accordingly. 
        movementDirection.Set(horizontalAxis, 0f, verticalAxis);

        // Normalise the movement vector and make it proportional to the speed per second.
        movementDirection = movementDirection.normalized * moveSpeed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidBody.velocity = (movementDirection * moveSpeed);

        //rotates the player so that it faces in the direction it is moving.
        Quaternion newRotation = Quaternion.LookRotation(lastMovement);
        playerRigidBody.MoveRotation(newRotation);

        if(playerRigidBody.velocity != Vector3.zero)
            lastMovement = playerRigidBody.velocity;
    }

    private void RestrictHeight()
    {
        if (transform.position.y < maxHeight)
        {
            maxHeight = transform.position.y;
        }
        //Debug.Log(maxHeight);
    }
}





