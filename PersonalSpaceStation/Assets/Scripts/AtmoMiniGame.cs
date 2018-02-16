using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmoMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    // UI
    /// <summary>
    /// All of these are the variables that are required to set up the minigames UI. The availableColors array is required to cycle between the different colors in 
    /// the game. 
    /// </summary>
    public Text completionText;
    public Image completionImage;
    Color[] availableColors = { Color.red, Color.blue, Color.green, Color.yellow };
    Color completionColor;
    int colorIndex = 0;

    // Computer
    /// <summary>
    /// Computer is the object that cycle through the different colors, using the available materials. 
    /// </summary>
    public GameObject computer;
    private Material computermaterial;

    // Completion mechanics
    /// <summary>
    /// The variables for keeping track of how close to completion the minigame is.
    /// </summary>
    public int completionCount = 3;
    private float completionCounter = 0;
    public int completionValue = 5;
    public bool isComplete = false;

    /// <summary>
    /// The variables for keeping track of the user, the station and tick for cycling through the different colors.
    /// </summary>
    public Interactable station;
    private string stationUser = "";
    private float lastTick;
    public float tickLength = 1f;

    /// <summary>
    /// get the mesh render for the the blocks that will change color. 
    /// </summary>
    private void Start()
    {
        if(computer != null)
        {
            computermaterial = computer.GetComponent<MeshRenderer>().material;
        }
    }

    /// <summary>
    /// the function for reseting the station before us, called in the Interactable script. Starts the NewColor method, to begin cycling through colors. 
    /// </summary>
    /// <param name="player"></param>
    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0;
        NewColor();
        completionText.text = completionCounter.ToString("0");
    }

    /// <summary>
    /// reset the color of the "computer" block to white.
    /// </summary>
    public void ResetComputer()
    {
        computermaterial.color = Color.white;
    }

    /// <summary>
    /// Randomise the color required to select. Calls once when the player first activates the minigame and then every time the player presses X until
    /// the player has chosen correctly three times or exits the minigame.
    /// </summary>
    void NewColor()
    {
        completionColor = availableColors[Random.Range(0, availableColors.Length)];

        if(availableColors[colorIndex] == completionColor)
        {
            completionColor = availableColors[(colorIndex + 3) % availableColors.Length];

        }

        completionImage.color = completionColor;
    }

    /// <summary>
    /// resets the computer and removes the active player from the stationUser string. 
    /// </summary>
    public void ResetUser()
    {
        stationUser = "";
        ResetComputer();
    }

    /// <summary>
    /// if the game is paused, the minigame does not continue cycling through colors. 
    /// </summary>
    void Update()
    {
        if (GameManager.instance.gameIsPaused == true)
        {
            return;
        }
        else
        {
            if (isComplete || stationUser == "")
                return;

            Tick();

            CheckCompletionCriteria();
            HandlePlayerInput();
        }
    }

    /// <summary>
    /// the method for advancing time and updating the computer screen.
    /// </summary>
    void Tick()
    {
        if (Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            UpdateComputerScreen();
        }
    }

    /// <summary>
    /// updates the computer screen with at random color each tick.
    /// </summary>
    void UpdateComputerScreen()
    {
        colorIndex = (colorIndex + 1) % availableColors.Length;
        computermaterial.color = availableColors[colorIndex];
    }

    /// <summary>
    /// set bool is not set here. If the player selects the correct color; the number of correct choices increase. 
    /// </summary>
    void HandlePlayerInput()
    {

        if (stationUser == "")
            return;

        if (Input.GetButtonDown("X-button" + stationUser))
        {
            if(completionColor == computermaterial.color)
            {
                //setbool för interacting här?
                completionCounter ++;
                completionText.text = completionCounter.ToString("0");
                NewColor();
            }
            else
            {
                if(completionCounter > 0)
                {
                    //setboolfalse här?
                    completionCounter--;
                    completionText.text = completionCounter.ToString("0");
                    NewColor();
                }
            }
        }

    }

    /// <summary>
    /// checks to see if the player has guessed correctly three times and if the player has the Coroutine CompleteMiniGame is run.
    /// </summary>
    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            completionText.text = "Done";
            StartCoroutine(CompleteMiniGame());
        }
    }

    /// <summary>
    /// resets the computer color to  white and adds health to the station. 
    /// </summary>
    /// <returns></returns>
    IEnumerator CompleteMiniGame()
    {
        computermaterial.color = Color.white;
        station.AddHealthToStation(completionValue);
        isComplete = true;
        stationUser = "";

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }
}
