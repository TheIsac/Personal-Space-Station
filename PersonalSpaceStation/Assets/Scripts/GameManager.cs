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

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //QualitySettings.vSyncCount = 4;
        //Application.targetFrameRate = 20;
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
