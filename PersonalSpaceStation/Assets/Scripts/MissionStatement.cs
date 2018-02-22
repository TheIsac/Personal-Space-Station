using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionStatement : MonoBehaviour {

    public GameObject missionStatementUI;

    private void Start()
    {
        missionStatementUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.gameIsPaused = true;
    }
    public void PressStartButton()
    {
        missionStatementUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.gameIsPaused = false;
    }
}
