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
    int colorIndex = 0;

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
            computermaterial = computer.GetComponent<MeshRenderer>().material;
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

    public void ResetComputer()
    {
        computermaterial.color = Color.white;
    }

    void NewColor()
    {
        completionColor = availableColors[Random.Range(0, availableColors.Length)];

        if(availableColors[colorIndex] == completionColor)
        {
            completionColor = availableColors[(colorIndex + 3) % availableColors.Length];

        }

        completionImage.color = completionColor;
    }

    public void ResetUser()
    {
        stationUser = "";
        ResetComputer();
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

            Tick();

            CheckCompletionCriteria();
            HandlePlayerInput();
        }
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
        colorIndex = (colorIndex + 1) % availableColors.Length;
        computermaterial.color = availableColors[colorIndex];
    }

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
