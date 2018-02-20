using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Interactable[] stationRooms;

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public Text enterName;
    public Text yourScore;

    public GameObject GameOverPanel;

    // Update is called once per frame;
    void Update()
    {
        int numberOfAliveRooms = 0;

        foreach (var room in stationRooms)
        {
            //If the rooms have more than 0 health they are alive;
            if (room.stationHealth > 0)
            {
                numberOfAliveRooms++;
            }
        }
        //if you have 1 room left alive then you lose and the game is over;
        if (!(numberOfAliveRooms > 1))
        {
            EndGame();
        }
    }
    //Ends the game and restarts the game.
    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            //Debug.Log("GAME OVER");
            //Invoke("Restart", restartDelay);
            //Restart();
            Time.timeScale = 0f;
            GameManager.instance.gameIsPaused = true;

            ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        GameOverPanel.SetActive(true);
        yourScore.text = FindObjectOfType<Scoring>().totalScore.ToString("000000");
    }

    public void OnNameEntered()
    {

        Debug.Log("Nik is the best!!");
        GameOverPanel.SetActive(false);

        FindObjectOfType<Scoring>().SortHighscores(enterName.text);
        gameHasEnded = true;
        // Add code to open the main menu
        GoBackToMainMenu();
        Time.timeScale = 1f;
    }

    void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
