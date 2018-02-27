using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    // UI, all the variables required for the UI elements. 
    public Sprite untickedBox;
    public Sprite tickedBox;
    public Sprite errorBox;
    //public Image[] colorBoxes;

    // New stuff
    int[] puzzle;
    public Sprite[] availablePlants;
    public Image[] plantBoxes;
    public Image[] resultBoxes;

    // variables for the puzzleboxes. 
    int boxIndex = 0;
    //public MeshRenderer[] puzzleBoxes;
 
    // Completion mechanics, variables.
    public int completionCount = 3;
    private float completionCounter = 0;
    public int completionValue = 5;
    public bool isComplete = false;

    //variables for the stations.
    public Interactable station;
    private string stationUser = "";

    /// <summary>
    /// if the game is paused the minigame is disabled.
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

            CheckCompletionCriteria();
            HandlePlayerInput();
        }
    }

    /// <summary>
    /// resets the station before use, and creates the five puzzles.
    /// </summary>
    /// <param name="player"></param>
    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0;
        boxIndex = 0;

        CreatePuzzle();
        ResetUI();
        LoadPuzzleUI();
    }

    /// <summary>
    /// resets the user and the puzzleboxes.
    /// </summary>
    public void ResetUser()
    {
        stationUser = "";
    }

    private void CreatePuzzle()
    {
        puzzle = new int[plantBoxes.Length];

        for (int i = 0; i < plantBoxes.Length; i++)
        {
            puzzle[i] = Random.Range(0, availablePlants.Length);
        }
    }

    private void LoadPuzzleUI()
    {
        for (int i = 0; i < plantBoxes.Length; i++)
        {
            plantBoxes[i].sprite = availablePlants[puzzle[i]];

            if(i != 0)
            {
                plantBoxes[i].color = new Color(1f, 1f, 1f, .05f);
            }
        }
    }

    /// <summary>
    /// handles the player input and adds to the completion counter if the player presses the correct colors. 
    /// </summary>
    void HandlePlayerInput()
    {

        if (stationUser == "" || boxIndex >= plantBoxes.Length)
            return;

        if (Input.GetButtonDown("Y-button" + stationUser))
        {
            if (puzzle[boxIndex] == 0)
            {
                resultBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
                AudioManager.instance.Play("Type");

                if(boxIndex < plantBoxes.Length)
                    plantBoxes[boxIndex].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                StartCoroutine(RestartLevel());
                AudioManager.instance.Play("Fail");
            }
        }
        if (Input.GetButtonDown("X-button" + stationUser))
        {
            if(puzzle[boxIndex] == 1)
            {
                resultBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
                AudioManager.instance.Play("Type");

                if (boxIndex < plantBoxes.Length)
                    plantBoxes[boxIndex].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                StartCoroutine(RestartLevel());
                AudioManager.instance.Play("Fail");
            }
        }
        if (Input.GetButtonDown("A-button" + stationUser))
        {
            if (puzzle[boxIndex] == 2)
            {
                resultBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
                AudioManager.instance.Play("Type");

                if (boxIndex < plantBoxes.Length)
                    plantBoxes[boxIndex].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                StartCoroutine(RestartLevel());
                AudioManager.instance.Play("Fail");
            }
        }

    }

    void ResetUI()
    {
        for (int i = 0; i < resultBoxes.Length; i++)
        {
            resultBoxes[i].sprite = untickedBox;
        }
    }

    /// <summary>
    /// restarts the level.
    /// </summary>
    /// <returns></returns>
    IEnumerator RestartLevel()
    {
        resultBoxes[boxIndex].sprite = errorBox;
        yield return new WaitForSeconds(.3f);
        ResetStation(stationUser);
    }

    /// <summary>
    /// checks if the player has completed the minigame and runs the Coroutine CompleteMiniGame. 
    /// </summary>
    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            station.AddHealthToStation(completionValue);
            isComplete = true;
            stationUser = "";

            station.MiniGameComplete();
            AudioManager.instance.Play("Pling");
        }
    }
}
