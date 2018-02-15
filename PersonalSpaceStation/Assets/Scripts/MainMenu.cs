using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text points;

	public void PlayGame()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene("CharacterSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowHighScore()
    {
        //points.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
