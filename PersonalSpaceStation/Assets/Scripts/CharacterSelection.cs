using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    //Default selection
    private int selection = 0;
    private int scoreUpdateInterval = 20;

    public string player;
    public List<GameObject> models = new List<GameObject>();
    public CharacterSelectionHandler doneSelecting;

    private void Start()
    {
        foreach(GameObject go in models)
        {
            go.SetActive(false);
        }

        models[selection].SetActive(true);
    }

    
    void Update()
    {
        if (Time.frameCount % scoreUpdateInterval == 0)
        {
            SelectCharacter();
        }
    }

    public void SelectCharacter()
    {
        
        if (Input.GetAxis("Horizontal" + player) > 0)
        {
            if(player == "_P1" && doneSelecting.player1Ready)
            {
                return;
            }
            if (player == "_P2" && doneSelecting.player2Ready)
            {
                return;
            }
            if (player == "_P3" && doneSelecting.player3Ready)
            {
                return;
            }
            if (player == "_P4" && doneSelecting.player4Ready)
            {
                return;
            }

            models[selection].SetActive(false);
            selection++;
            if (selection >= models.Count)
            {
                selection = 0;
            }
            models[selection].SetActive(true);
        }
        if (Input.GetAxis("Horizontal" + player) < 0)
        {
            if (player == "_P1" && doneSelecting.player1Ready)
            {
                return;
            }
            if (player == "_P2" && doneSelecting.player2Ready)
            {
                return;
            }
            if (player == "_P3" && doneSelecting.player3Ready)
            {
                return;
            }
            if (player == "_P4" && doneSelecting.player4Ready)
            {
                return;
            }
            models[selection].SetActive(false);
            selection--;
            if (selection < 0)
            {
                selection = models.Count - 1;
            }
            models[selection].SetActive(true);
        }
    }

}
