using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameOverMenu gameOverMenu;
    public MissionStatement missionStatementUI;

	// Update is called once per frame
	void Update () {

        if (!GameManager.instance.gameIsPaused && !missionStatementUI.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Menu-button_All"))
            {
                if (GameManager.instance.gameIsPaused)
                {
                    if (!gameOverMenu.gameHasEnded)
                    {
                    Resume();
                    }
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        StartCoroutine("ResumeCo");
    }

    IEnumerator ResumeCo()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.gameIsPaused = false;
    }

     void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.gameIsPaused = true;
    }

    public void LoadSettings()
    {
        Debug.Log("Loading settings..");

    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu..");

        Time.timeScale = 1f;
        SceneManager.LoadScene("Main menu 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }
}
