using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardPause : MonoBehaviour {

    private bool gameIsPaused = false;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameManager.instance.gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        Time.timeScale = 0f;
        GameManager.instance.gameIsPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        GameManager.instance.gameIsPaused = false;
    }
}
