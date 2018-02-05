using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGenerator : MonoBehaviour {

    public bool courier = false;

    public int successCounter = 0;

    public GameObject documents;
    public Transform docSpawnPoint;

	// Use this for initialization
	void Start () {

    }

    //recieve signal from Interactable, that a station was fixed and count the success
    public void DocumentGenerator()
    {
        if (successCounter < 3)
        {
            successCounter += 1;
        }
        else if (successCounter == 3)
        {
            successCounter = 0;

            SpawnPaperWork();

            successCounter += 1;
        }
    }
    public void SpawnPaperWork()
    {
        Instantiate(documents, docSpawnPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(/*player carries a document of right type*/)
        //{
        //    courier = true;
        //}
    }
}
