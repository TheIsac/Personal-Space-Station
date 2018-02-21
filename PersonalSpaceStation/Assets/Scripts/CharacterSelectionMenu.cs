using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour {

    // public Character[] characters;
    //public Vector3 playerSpawnPosition = new Vector3(0, 1, -7);
   // public GameObject player;


    // Use this for initialization
    public void PlayGame()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene("IsacSpeltest 1");
       // GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
        //Character selectedCharacter = characters[characterChoice];
    }
    
    public void BacktoMenu()
    {
        //If the back button is pressed you go back to the Main Menu.
        SceneManager.LoadScene("Main menu");
    }
}
