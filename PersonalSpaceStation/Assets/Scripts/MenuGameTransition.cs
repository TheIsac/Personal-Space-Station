using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameTransition : MonoBehaviour {

    public GameObject p1, p2, p3, p4;
    private GameObject p1Char, p2Char, p3Char, p4Char;

    public GameObject CharacterSelector;

    public bool p1Ready, p2Ready, p3Ready, p4Ready;

    private bool otherP1Ready, otherP2Ready, otherP3Ready, otherP4Ready;

    private GameObject p1Selection, p2Selection, p3Selection, p4Selection;

    private int modulTick;
    private int counter;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckActivePlayers();
    }

    void CheckActivePlayers()
    {
        modulTick = counter % 4;
        switch (modulTick)
        {
            case 0:
                p1Ready = CharacterSelector.GetComponent<CharacterSelectionHandler>().player1Ready;
                break;
            case 1:
                p2Ready = CharacterSelector.GetComponent<CharacterSelectionHandler>().player2Ready;
                break;
            case 2:
                p3Ready = CharacterSelector.GetComponent<CharacterSelectionHandler>().player3Ready;
                break;
            case 3:
                p4Ready = CharacterSelector.GetComponent<CharacterSelectionHandler>().player4Ready;
                break;
            default:
                break;
        }
        counter++;
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main menu");
    }
}
