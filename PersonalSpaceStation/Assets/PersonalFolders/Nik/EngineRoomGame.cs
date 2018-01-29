using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRoomGame : MonoBehaviour {

    public GameObject miniGame;
    public bool inUse = false;
    private bool playerInRange = false;

	void Start () {
        
	}
	
	void Update () {
		if(playerInRange)
        {
            HandlePlayerInput();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    private void HandlePlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inUse)
            {
                inUse = false;
                miniGame.SetActive(false);
            }
            else
            {
                inUse = true;
                miniGame.SetActive(true);
            }

        }
    }
}
