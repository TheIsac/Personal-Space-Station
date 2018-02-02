using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class CharacterSelectionHandler : MonoBehaviour {

    private bool playerSelect = false;
    private bool playerJoined1 = false;
    private bool playerJoined2 = false;
    private bool playerJoined3 = false;
    private bool playerJoined4 = false;
    private int numberOfPlayers;

    public Button start;
    public Image playerSelectBackground;
    public Button selectCharacters;

    public Button[] playerButton;
    public Image[] playerColor;
    public Text[] playerText;

	// Use this for initialization
	void Start ()
    {
        numberOfPlayers = 0;
	}

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    public void PlayerInput()
    {
            if (Input.GetButtonDown("A-button_P1") && playerSelect == false)
            {
                playerSelect = true;
            }

            if (playerSelect == true)
            {
                if (Input.GetButtonDown("A-button_P1") && playerJoined1 == false)
                {
                    PlayerJoin(0);
                    playerJoined1 = true;
                }
                if (Input.GetButtonDown("A-button_P2") && playerJoined1 == false)
                {
                    PlayerJoin(1);
                    playerJoined2 = true;
                }
                if (Input.GetButtonDown("A-button_P3") && playerJoined1 == false)
                {
                    PlayerJoin(2);
                    playerJoined3 = true;
                }
                if (Input.GetButtonDown("A-button_P4") && playerJoined1 == false)
                {
                    PlayerJoin(3);
                    playerJoined4 = true;
                }
            }
        }

    public void PlayerJoin(int index)
    {
        playerButton[index].gameObject.SetActive(false);
        playerColor[index].gameObject.SetActive(true);
        playerText[index].gameObject.SetActive(true);
        numberOfPlayers += 1;
    }
}
