using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    public GameObject Engine;
    public GameObject Atmos;
    public GameObject Plant;
    public GameObject Water;

    float engineHealth;
    float atmosHealth;
    float plantHealth;
    float waterHealth;
   

    bool gameHasEnded = false;

    public float restartDelay = 1f;
	// Use this for initialization


	void Start () {
        

    }

    // Update is called once per frame
    void Update()
    {
        engineHealth = Engine.GetComponent<Interactable>().stationHealth;
        atmosHealth = Atmos.GetComponent<Interactable>().stationHealth;
        plantHealth = Plant.GetComponent<Interactable>().stationHealth;
        waterHealth = Water.GetComponent<Interactable>().stationHealth;
        if ()
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
