using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Interactable[] stationRooms;

    bool gameHasEnded = false;

    public float restartDelay = 1f;

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
            FindObjectOfType<Scoring>().SortHighscores();
            gameHasEnded = true;
            //Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
            //Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
