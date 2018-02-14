using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.instance.Play("GameMusic");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
