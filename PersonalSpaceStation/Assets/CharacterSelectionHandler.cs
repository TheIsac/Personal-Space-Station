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
    public Button playerReady1;
    public Button playerReady2;
    public Button playerReady3;
    public Button playerReady4;
    public bool player1Ready;
    public bool player2Ready;
    public bool player3Ready;
    public bool player4Ready;

    //public Text start;
    public Image playerSelectBackground;
    public Button selectCharacters;

    public GameObject[] player;
    //public Button[] playerButton;
    //public Image[] playerColor;
    //public Text[] playerText;
    public GameObject[] selectCharacter;

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
                //start.gameObject.SetActive(false);
            }

            if (Input.GetButtonDown("B-button_P1") && numberOfPlayers == 0)
            {
                //leave the character selection screen.
            }

            if (playerSelect == true)
            {
            //Player One
                if (Input.GetButtonDown("A-button_P1") && playerJoined1 == false)
                {
                    PlayerJoin(0);
                    playerJoined1 = true;
                    player[0].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("X-button_P1") && playerJoined1 == true)
                {
                    playerReady1.gameObject.SetActive(true);
                    player1Ready = true;
                }
                if (Input.GetButtonDown("B-button_P1") && playerJoined1 == true)
                {
                    playerReady1.gameObject.SetActive(false);
                    player1Ready = false;
                }

            //Player Two
                if (Input.GetButtonDown("A-button_P2") && playerJoined2 == false)
                {
                    PlayerJoin(1);
                    playerJoined2 = true;
                    player[1].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("X-button_P2") && playerJoined2 == true)
                {
                    playerReady2.gameObject.SetActive(true);
                    player2Ready = true;
                }
                if (Input.GetButtonDown("B-button_P2") && playerJoined2 == true)
                {
                    playerReady2.gameObject.SetActive(false);
                    player2Ready = false;
                }
            //Player Three
                if (Input.GetButtonDown("A-button_P3") && playerJoined3 == false)
                {
                    PlayerJoin(2);
                    playerJoined3 = true;
                    player[2].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("X-button_P3") && playerJoined3 == true)
                {
                    playerReady3.gameObject.SetActive(true);
                    player3Ready = true;   
                }
                if (Input.GetButtonDown("B-button_P3") && playerJoined3 == true)
                {
                    playerReady3.gameObject.SetActive(false);
                    player3Ready = false;
                }
            //Player Four
                if (Input.GetButtonDown("A-button_P4") && playerJoined4 == false)
                {
                    PlayerJoin(3);
                    playerJoined4 = true;
                    player[3].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("X-button_P4") && playerJoined4 == true)
                {
                    playerReady4.gameObject.SetActive(true);
                    player4Ready = true;
                }
                if (Input.GetButtonDown("B-button_P4") && playerJoined4 == true)
                {
                    playerReady4.gameObject.SetActive(false);
                    player4Ready = false;
                }
        }
    }

    public void PlayerJoin(int index)
    {
        if (index > 4)
        {
            return;
        }
        
            //playerButton[index].gameObject.SetActive(false);
            //playerColor[index].gameObject.SetActive(true);
            //playerText[index].gameObject.SetActive(true);
            selectCharacter[index].gameObject.SetActive(true);
            numberOfPlayers += 1;
    }
}
