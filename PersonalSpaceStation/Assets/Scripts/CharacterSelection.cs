using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {


    //Default selection
    private int selection = 0;

    public List<GameObject> models = new List<GameObject>();

    private void Start()
    {
        foreach(GameObject go in models)
        {
            go.SetActive(false);
        }

        models[selection].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            models[selection].SetActive(false);
            selection++;
            if (selection >= models.Count)
            {
                selection = 0;
            }
            models[selection].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            models[selection].SetActive(false);
            selection--;
            if (selection < 0)
            {
                selection = models.Count-1;
            }
            models[selection].SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    PlayerPrefs.SetInt("PreferedModel", selection);
        //    Application.LoadLevel("Game");
        //}
    }
    public void GoBack()
    {
        //Load next scene in the scene build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
