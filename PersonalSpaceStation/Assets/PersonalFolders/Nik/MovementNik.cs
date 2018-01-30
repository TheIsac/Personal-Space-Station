using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNik : MonoBehaviour
{

    //Variables
    private float horizontalAxis;
    private float verticalAxis;
    //defined in the inspector of every character object.
    public float moveSpeed;

    public string player;
   
    private Vector3 movementDirection;

    public bool inMiniGame;

    Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inMiniGame)
        {
            horizontalAxis = 0;
            verticalAxis = 0;

            if (Mathf.Abs(Input.GetAxis("Horizontal" + player)) > .7f)
                horizontalAxis = Input.GetAxis("Horizontal" + player);

            if (Mathf.Abs(Input.GetAxis("Vertical" + player)) > .7f)
                verticalAxis = Input.GetAxis("Vertical" + player);

            CharacterMovement();
        }
        //the string player is defined in the inspector in unity, and in the input manager in unity there are one horizontal/vertical input for each player.   
    }

    public void CharacterMovement()
    {
        //move the character using the input from the individual axises, and transform the position accordingly. 
        movementDirection.Set(horizontalAxis, 0f, verticalAxis);

        // Normalise the movement vector and make it proportional to the speed per second.
        movementDirection = movementDirection.normalized * moveSpeed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rb.MovePosition(transform.position + movementDirection);
        
       
    
        Quaternion.LookRotation(movementDirection);
    }
}





