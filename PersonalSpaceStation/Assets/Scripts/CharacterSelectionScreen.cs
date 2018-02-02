using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScreen : MonoBehaviour {

    private int lockedCharacters;

    //Array of how many players are locked in

	void Start ()
    {
        //if (in scene characterselection)
        //{
        if (Input.GetButtonDown("B-button_P1") && lockedCharacters == 0)
        {
            GoBack();
        }
        //    if (Input.GetButtonDown("A-button" + player)
        //    {
        //        lock character
        //    }
        //    if (Input.GetButtonDown("B-button" and locked character)
        //    {
        //        unlock character
        //    }
        //    if (characterselection locked){
        //        if (Input.GetButtonDown("A-button")
        //            {
        //            lock character
        //            }
        //    }
        //}
    }
    public void GoBack()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
