using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    //Default selection and variables for setting up the selection. 
    public int selection = 0;

    private float nextUpdate = 0f;
    private float AutoUpdateInterval = .5f;

    public string player;
    public List<GameObject> models = new List<GameObject>();
    public CharacterSelectionHandler doneSelecting;

    //starts up the character selection.
    private void Start()
    {
        foreach(GameObject go in models)
        {
            go.SetActive(false);
        }

        models[selection].SetActive(true);
    }

    // SelectCharacter is run.
    void Update()
    {
        SelectCharacter();
    }

    /// <summary>
    /// updates the selection at certain intervalls and cycles through the different models either backwards or forwards depending on the
    /// input from the player. 
    /// </summary>
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
