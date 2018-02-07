using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene("CharacterSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
