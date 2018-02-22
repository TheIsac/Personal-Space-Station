using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text gameOverText;

    public bool gameIsPaused = false;

    [Header("Difficulty Settings")]
    public float difficultyInterval = 30f;
    public float stationDifficultyAdjustment = .1f;
    public float stationTickLength = 3f;
    private float lastTick;
    public int overloadThreshhold = 70;

    Dictionary<Station, GameObject> handInUIDictionary = new Dictionary<Station, GameObject>();

    public GameObject atmoHandIn;
    public GameObject plantHandIn;
    public GameObject engineHandIn;
    public GameObject pumpHandIn;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //QualitySettings.vSyncCount = 4;
        //Application.targetFrameRate = 20;
    }

    private void Start()
    {
        handInUIDictionary.Add(Station.AtmoRoom, atmoHandIn);
        handInUIDictionary.Add(Station.EngineRoom, engineHandIn);
        handInUIDictionary.Add(Station.PlantRoom, plantHandIn);
        handInUIDictionary.Add(Station.WaterPumps, pumpHandIn);
    }

    public void ToggleHandInUI(Station targetStation, bool active)
    {
        handInUIDictionary[targetStation].SetActive(active);
    }

    private void Update()
    {
        Tick();
    }

    void Tick()
    {
        if (Time.time - lastTick > difficultyInterval)
        {
            lastTick = Time.time;

            UpdateDifficulty();
        }
    }

    private void UpdateDifficulty()
    {
        stationTickLength -= stationDifficultyAdjustment;
    }

    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);

        GetComponent<GameOverMenu>().EndGame();
    }
}
