using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPointScore : MonoBehaviour {

    public Text highScoreText;
    int highScore;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }
	

}
