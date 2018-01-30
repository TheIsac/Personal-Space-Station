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

    public bool inMiniGame;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inMiniGame)
        {
            return;
        }
        //the string player is defined in the inspector in unity, and in the input manager in unity there are one horizontal/vertical input for each player.
        horizontalAxis = Input.GetAxis("Horizontal" + player);
        verticalAxis = Input.GetAxis("Vertical" + player);
        CharacterMovement();
    }

    public void CharacterMovement()
    {
        //move the character using the input from the individual axises, and transform the position accordingly. 
        movementDirection = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        transform.position += movementDirection * moveSpeed * Time.deltaTime;
        Quaternion.LookRotation(movementDirection);
    }
}





