﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    //Default selection
    public int selection = 0;

    private float nextUpdate = 0f;
    private float AutoUpdateInterval = .5f;

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
        SelectCharacter();
    }

    public void SelectCharacter()
    {
        nextUpdate -= Time.deltaTime;

        float input = Input.GetAxis("Horizontal" + player);

        if (Mathf.Abs(input) > .1f)
        {
            if (doneSelecting.IsDoneSelecting(player))
                return;

            if (nextUpdate > 0)
                return;

            models[selection].SetActive(false);

            // Select the next or previous model in the array depending on input
            selection = ((selection + models.Count + (int)Mathf.Sign(input)) % models.Count);

            models[selection].SetActive(true);
            nextUpdate = AutoUpdateInterval;
        }
        else
        {
            // Reset the update timer if the player no longer gives any input on the controller.
            nextUpdate = 0f;
        }
    }
}
