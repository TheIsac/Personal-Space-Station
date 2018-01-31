using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmoMiniGame : MonoBehaviour, IResetUser, IResetStation
{

    // UI
    public Text completionText;
    public Image completionImage;
    Color[] availableColors = { Color.red, Color.blue, Color.green, Color.yellow };
    Color completionColor;

    // Computer
    public GameObject computer;
    private Material computermaterial;

    // Completion mechanics
    public int completionCount = 3;
    private float completionCounter = 0;
    public int completionValue = 5;
    public bool isComplete = false;

    public Interactable station;
    private string stationUser = "";
    private float lastTick;
    public float tickLength = 1f;

    private void Start()
    {
        if(computer != null)
        {
            computermaterial = computer.GetComponent<MeshRenderer>().sharedMaterial;
        }
    }

    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0;
        NewColor();
        completionText.text = completionCounter.ToString("0");
    }

    void NewColor()
    {
        completionColor = availableColors[Random.Range(0, availableColors.Length)];
        completionImage.color = completionColor;
    }

    public void ResetUser()
    {
        stationUser = "";
    }

    void Update()
    {
        if (isComplete || stationUser == "")
            return;

        Tick();

        CheckCompletionCriteria();
        HandlePlayerInput();
    }

    void Tick()
    {
        if (Time.time - lastTick > tickLength)
        {
            lastTick = Time.time;
            UpdateComputerScreen();
        }
    }

    void UpdateComputerScreen()
    {
        computermaterial.color = availableColors[Random.Range(0, availableColors.Length)];
    }

    void HandlePlayerInput()
    {

        if (stationUser == "")
            return;

        if (Input.GetButtonDown("X-button" + stationUser))
        {
            if(completionColor == computermaterial.color)
            {
                completionCounter += 1;
                completionText.text = completionCounter.ToString("#");
                NewColor();
            }
        }

    }

    void CheckCompletionCriteria()
    {
        if (completionCounter >= completionCount)
        {
            completionText.text = "Done";
            StartCoroutine(CompleteMiniGame());
        }
    }

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
