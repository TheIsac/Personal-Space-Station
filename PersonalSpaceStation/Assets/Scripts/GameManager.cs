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
    Dictionary<Station, DocGenerator> stationToDocGenerator = new Dictionary<Station, DocGenerator>();

    public GameObject atmoHandIn;
    public GameObject plantHandIn;
    public GameObject engineHandIn;
    public GameObject pumpHandIn;

    public DocGenerator atmoStation;
    public DocGenerator engineRoom;
    public DocGenerator pumpStation;
    public DocGenerator plantStation;


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

        stationToDocGenerator.Add(Station.AtmoRoom, atmoStation);
        stationToDocGenerator.Add(Station.EngineRoom, engineRoom);
        stationToDocGenerator.Add(Station.PlantRoom, pumpStation);
        stationToDocGenerator.Add(Station.WaterPumps, plantStation);
    }

    public void ToggleHandInUI(Station targetStation, bool active)
    {
        // Not the prettiest of solutions, this was just a fast last minute thing before handing in
        // Previously this code would just turn off the handin icons whenever a document was handed in but there could be several 
        // documents destined for the same handin location
        if(active)
        {
            stationToDocGenerator[targetStation].documentsWaitingForHandin++;
        }
        else
        {
            stationToDocGenerator[targetStation].documentsWaitingForHandin--;
        }

        handInUIDictionary[targetStation].SetActive(stationToDocGenerator[targetStation].documentsWaitingForHandin > 0);
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
