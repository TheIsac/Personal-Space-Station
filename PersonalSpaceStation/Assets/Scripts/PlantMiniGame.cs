using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    // UI
    //public Text completionText;
    public Sprite untickedBox;
    public Sprite tickedBox;
    public Sprite errorBox;
    public Image[] colorBoxes;

    int boxIndex = 0;

    public MeshRenderer[] puzzleBoxes;
 
    // Completion mechanics
    public int completionCount = 3;
    private float completionCounter = 0;
    public int completionValue = 5;
    public bool isComplete = false;
    List<ColorPuzzle> puzzles = new List<ColorPuzzle>();

    ColorPuzzle currentPuzzle;

    public Interactable station;
    private string stationUser = "";

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

    public void ResetUser()
    {
        stationUser = "";
        ResetBoxes();
        ResetPuzzleBoxes();
    }

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

    void ResetPuzzleBoxes()
    {
        for (int i = 0; i < puzzleBoxes.Length; i++)
        {
            puzzleBoxes[i].material.color = Color.white;
        }
    }

    void ResetBoxes()
    {
        for (int i = 0; i < colorBoxes.Length; i++)
        {
            colorBoxes[i].sprite = untickedBox;
        }

        boxIndex = 0;
    }

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

    IEnumerator RestartLevel()
    {
        colorBoxes[boxIndex].sprite = errorBox;
        yield return new WaitForSeconds(.3f);
        ResetStation(stationUser);
    }

    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            StartCoroutine(CompleteMiniGame());
        }
    }

    IEnumerator CompleteMiniGame()
    {
        station.AddHealthToStation(completionValue);
        isComplete = true;
        stationUser = "";
        ResetPuzzleBoxes();

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }

    private void CreatePuzzles(int numberOfPuzzles)
    {
        puzzles.Clear();

        for (int i = 0; i < numberOfPuzzles; i++)
        {
            puzzles.Add(new ColorPuzzle());
        }
    }



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
