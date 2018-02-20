using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class CharacterSelectionHandler : MonoBehaviour {

    //the different variables for playerSelect and character selection. 
    private bool playerSelect = false;
    public CharacterSelection[] playerchoice;

    //sets as true when the individual players press A
    private bool playerJoined1 = false;
    private bool playerJoined2 = false;
    private bool playerJoined3 = false;
    private bool playerJoined4 = false;

    //keeps track of how many players have joined
    private int numberOfPlayers;

    //shows the button checked if the player has pressed A, removes it if they press B
    public Button playerReady1;
    public Button playerReady2;
    public Button playerReady3;
    public Button playerReady4;

    //wether or not the player is ready
    public bool player1Ready;
    public bool player2Ready;
    public bool player3Ready;
    public bool player4Ready;

    //public Text start;
    public Image playerSelectBackground;
    public Button startGame;
    
    public GameObject[] player;
    //public Button[] playerButton;
    //public Image[] playerColor;
    //public Text[] playerText;
    public GameObject[] selectCharacter;
    public Button[] join;
    public Button[] ready;
    public Image[] arrows;
    

	// Use this for initialization
	void Start ()
    {
        numberOfPlayers = 0;
        startGame.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        StartGame();
    }

    //switch function that enables the different ready states when a player is done selecting.
    public bool IsDoneSelecting(string playerString)
    {
        switch (playerString)
        {
            case "_P1":
                return player1Ready;
            case "_P2":
                return player2Ready;
            case "_P3":
                return player3Ready;
            case "_P4":
                return player4Ready;
            default:
                return false;
        }
    }

    public void PlayerInput()
    {
            if (playerSelect == false)
            {
                playerSelect = true;
            }

            if (Input.GetButtonDown("B-button_P1") && numberOfPlayers == 0)
            {
                SceneManager.LoadScene("Main menu");
            }

            if (playerSelect == true)
            {

            //Player One, Handles input for A and B button.
                if (Input.GetButtonDown("A-button_P1") && playerJoined1 == true)
                {
                    //If player 1 presses A it is readied and the button for ready appears
                    player1Ready = true;
                    PlayerPrefs.SetInt("player1", playerchoice[0].selection);
                    Debug.Log(playerchoice[0].selection);
                    ready[0].gameObject.SetActive(true);

                }
            if (Input.GetButtonDown("A-button_P1") && playerJoined1 == false)
                {
                    //If player 1 presses A, the player one is added to the joined players and the player can choose model.
                    PlayerJoin(0);
                    playerJoined1 = true;
                    join[0].gameObject.SetActive(false);
                    playerReady1.gameObject.SetActive(true);
                    player[0].gameObject.SetActive(true);
                
                }
               
                if (Input.GetButtonDown("B-button_P1") && player1Ready == true)
                {
                    //If player 1 is ready, and presses B then the player is no longer ready and can change model again.
                    playerReady1.gameObject.SetActive(true);
                    player1Ready = false;
                    startGame.gameObject.SetActive(false);
                    ready[0].gameObject.SetActive(false);
            }               

            //Player Two, Handles input for A and B button.
                if (Input.GetButtonDown("A-button_P2") && playerJoined2 == true)
                {
                //If player 2 presses A it is readied and the button for ready appears
                    playerReady2.gameObject.SetActive(true);
                    player2Ready = true;
                    PlayerPrefs.SetInt("player2", playerchoice[1].selection);
                    ready[1].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("A-button_P2") && playerJoined2 == false)
                {
                    //If player 2 presses A, the player one is added to the joined players and the player can choose model.
                    PlayerJoin(1);
                    playerJoined2 = true;
                    join[1].gameObject.SetActive(false);
                    player[1].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("B-button_P2") && player2Ready == true)
                {
                    //If player 2 is ready, and presses B then the player is no longer ready and can change model again.
                    playerReady2.gameObject.SetActive(true);
                    player2Ready = false;
                    startGame.gameObject.SetActive(false);
                    ready[0].gameObject.SetActive(false);
            }
                
            //Player Three, Handles input for A and B button.
                if (Input.GetButtonDown("A-button_P3") && playerJoined3 == true)
                {
                //If player 3 presses A it is readied and the button for ready appears
                    playerReady3.gameObject.SetActive(true);
                    player3Ready = true;
                    PlayerPrefs.SetInt("player3", playerchoice[2].selection);
                    ready[2].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("A-button_P3") && playerJoined3 == false)
                {
                    //If player 3 presses A, the player three is added to the joined players and the player can choose model.
                    PlayerJoin(2);
                    playerJoined3 = true;
                    join[2].gameObject.SetActive(false);
                    player[2].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("B-button_P3") && player3Ready == true)
                {
                    //If player 3 is ready, and presses B then the player is no longer ready and can change model again
                    playerReady3.gameObject.SetActive(true);
                    player3Ready = false;
                    startGame.gameObject.SetActive(false);
                    ready[2].gameObject.SetActive(false);
            }
            //Player Four, Handles input for A and B button.
                if (Input.GetButtonDown("A-button_P4") && playerJoined4 == true)
                {
                //If player 4 presses A it is readied and the button for ready appears
                    playerReady4.gameObject.SetActive(true);
                    player4Ready = true;
                    PlayerPrefs.SetInt("player4", playerchoice[3].selection);
                    ready[3].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("A-button_P4") && playerJoined4 == false)
                {
                    //If player 4 presses A, the player four is added to the joined players and the player can choose model.
                    PlayerJoin(3);
                    playerJoined4 = true;
                    join[3].gameObject.SetActive(false);
                    player[3].gameObject.SetActive(true);
                }
                if (Input.GetButtonDown("B-button_P4") && player4Ready == true)
                {
                //If player 4 is ready, and presses B then the player is no longer ready and can change model again
                    playerReady4.gameObject.SetActive(true);
                    player4Ready = false;
                    startGame.gameObject.SetActive(false);
                    ready[3].gameObject.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        //the start game button only appears if the same number of players that have joined the game indicates that they're ready. 
        if (numberOfPlayers > 0)
        {
            if (numberOfPlayers == 1 && player1Ready)
            {
                startGame.gameObject.SetActive(true);
            }

            if (numberOfPlayers == 2 && player1Ready && player2Ready)
            {
                startGame.gameObject.SetActive(true);
            }

            if (numberOfPlayers == 3 && player1Ready && player2Ready && player3Ready)
            {
                startGame.gameObject.SetActive(true);
            }

            if (numberOfPlayers == 4 && player1Ready && player2Ready && player3Ready && player4Ready)
            {
                startGame.gameObject.SetActive(true);
            }
        }
    }


    //Not sure if this is required, maybe I can do this in the input section instead?
    public void PlayerJoin(int index)
    {
        if (index > 4)
        {
            return;
        }
        
            //playerButton[index].gameObject.SetActive(false);
            //playerColor[index].gameObject.SetActive(true);
            arrows[index].gameObject.SetActive(true);
            selectCharacter[index].gameObject.SetActive(true);
            numberOfPlayers += 1;
    }
}
