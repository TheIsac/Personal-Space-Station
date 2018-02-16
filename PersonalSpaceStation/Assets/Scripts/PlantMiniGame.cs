using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    // UI, all the variables required for the UI elements. 
    //public Text completionText;
    public Sprite untickedBox;
    public Sprite tickedBox;
    public Sprite errorBox;
    public Image[] colorBoxes;

    // variables for the puzzleboxes. 
    int boxIndex = 0;
    public MeshRenderer[] puzzleBoxes;
 
    // Completion mechanics, variables.
    public int completionCount = 3;
    private float completionCounter = 0;
    public int completionValue = 5;
    public bool isComplete = false;
    List<ColorPuzzle> puzzles = new List<ColorPuzzle>();

    ColorPuzzle currentPuzzle;

    //variables for the stations.
    public Interactable station;
    private string stationUser = "";


    /// <summary>
    /// resets the station before use, and creates the five puzzles.
    /// </summary>
    /// <param name="player"></param>
    public void ResetStation(string player)
    {
        if(puzzles.Count < 1)
            CreatePuzzles(5);

        stationUser = player;
        isComplete = false;
        completionCounter = 0;
        ResetPuzzleBoxes();
        ResetBoxes();
        LoadNewPuzzle();
    }

    /// <summary>
    /// resets the user and the puzzleboxes.
    /// </summary>
    public void ResetUser()
    {
        stationUser = "";
        ResetBoxes();
        ResetPuzzleBoxes();
    }

    /// <summary>
    /// Loads a new puzzle and gives the boxes a random set of colors.
    /// </summary>
    void LoadNewPuzzle()
    {
        currentPuzzle = puzzles[Random.Range(0, puzzles.Count)];

        for (int i = 0; i < currentPuzzle.colorSequence.Length; i++)
        {
            if(puzzleBoxes.Length > i)
            {
                puzzleBoxes[i].material.color = currentPuzzle.colorSequence[i];
            }
        }
    }

    /// <summary>
    /// resets the puzzleboxes to white.
    /// </summary>
    void ResetPuzzleBoxes()
    {
        for (int i = 0; i < puzzleBoxes.Length; i++)
        {
            puzzleBoxes[i].material.color = Color.white;
        }
    }

    /// <summary>
    /// resets the boxes in the minigame screen.
    /// </summary>
    void ResetBoxes()
    {
        for (int i = 0; i < colorBoxes.Length; i++)
        {
            colorBoxes[i].sprite = untickedBox;
        }

        boxIndex = 0;
    }

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
    /// handles the player input and adds to the completion counter if the player presses the correct colors. 
    /// </summary>
    void HandlePlayerInput()
    {

        if (stationUser == "" || boxIndex >= colorBoxes.Length)
            return;

        if (Input.GetButtonDown("Y-button" + stationUser))
        {
            if (currentPuzzle.colorSequence[boxIndex] == Color.yellow)
            {
                colorBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
            }
            else
            {
                StartCoroutine(RestartLevel());
            }
        }
        if (Input.GetButtonDown("X-button" + stationUser))
        {
            if(currentPuzzle.colorSequence[boxIndex] == Color.blue)
            {
                colorBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
            }
            else
            {
                StartCoroutine(RestartLevel());
            }
        }
        if (Input.GetButtonDown("A-button" + stationUser))
        {
            if (currentPuzzle.colorSequence[boxIndex] == Color.green)
            {
                colorBoxes[boxIndex].sprite = tickedBox;
                boxIndex++;
                completionCounter++;
            }
            else
            {
                StartCoroutine(RestartLevel());
            }
        }

    }

    /// <summary>
    /// restarts the level.
    /// </summary>
    /// <returns></returns>
    IEnumerator RestartLevel()
    {
        colorBoxes[boxIndex].sprite = errorBox;
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
            StartCoroutine(CompleteMiniGame());
        }
    }

    /// <summary>
    /// completes the game and resets the puzzleboxes.
    /// </summary>
    /// <returns></returns>
    IEnumerator CompleteMiniGame()
    {
        station.AddHealthToStation(completionValue);
        isComplete = true;
        stationUser = "";
        ResetPuzzleBoxes();

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }

    /// <summary>
    /// creates the puzzles for the game.
    /// </summary>
    /// <param name="numberOfPuzzles"></param>
    private void CreatePuzzles(int numberOfPuzzles)
    {
        puzzles.Clear();

        for (int i = 0; i < numberOfPuzzles; i++)
        {
            puzzles.Add(new ColorPuzzle());
        }
    }


    /// <summary>
    /// determines the available colors and gives each box a random color. 
    /// </summary>
    public class ColorPuzzle
    {
        int puzzleLength = 5;
        public Color[] colorSequence;
        Color[] availableColors = { Color.blue, Color.green, Color.yellow };

        public ColorPuzzle()
        {
            colorSequence = new Color[puzzleLength];

            for (int i = 0; i < colorSequence.Length; i++)
            {
                colorSequence[i] = GetRandomColor();
            }
        }

        Color GetRandomColor()
        {
            return availableColors[Random.Range(0, availableColors.Length)];
        }
    }
}
