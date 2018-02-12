using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text gameOverText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //QualitySettings.vSyncCount = 4;
        //Application.targetFrameRate = 20;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

        GetComponent<GameOverMenu>().EndGame();
    }
}
