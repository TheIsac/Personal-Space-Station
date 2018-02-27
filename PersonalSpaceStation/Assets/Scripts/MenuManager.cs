using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.instance.Stop("GameMusic");
        AudioManager.instance.Play("MenuMusic");
	}
}
