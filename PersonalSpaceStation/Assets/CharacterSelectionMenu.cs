using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour {

    // Use this for initialization
    public void PlayGame()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene("IsacSpeltest");
    }
    // Update is called once per frame
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
