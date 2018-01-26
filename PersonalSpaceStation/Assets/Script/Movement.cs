using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Variables
    [HideInInspector] public float horizontalAxis;
    [HideInInspector] public float verticalAxis;
    public string player;
    public float moveSpeed;

    private Vector3 movementDirection;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal" + player);
        verticalAxis = Input.GetAxis("Vertical" + player);
        CharacterMovement();
    }

    public void CharacterMovement()
    {
        movementDirection = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        transform.position += movementDirection * moveSpeed;
        Quaternion.LookRotation(movementDirection);
    }
}





