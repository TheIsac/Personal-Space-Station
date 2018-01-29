using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject player;
    private Vector3 currentPos;
    private Quaternion currentQuat;


	void Start () {
        currentPos = gameObject.transform.position;
        currentQuat = Quaternion.Euler(0, 0, 0);

        Instantiate(player, currentPos, currentQuat);
	}
}
