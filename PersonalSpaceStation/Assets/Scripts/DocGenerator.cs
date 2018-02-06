using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGenerator : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public int successCounter = 0;

    public GameObject documents;
    public Transform docSpawnPoint;

    //public Document document;

    public Interactable myStation;

	// Use this for initialization
	void Start () {
   
    }

    //recieve signal from Interactable, that a station was fixed and count the success
    public void DocumentGenerator()
    {
        Debug.Log(successCounter);
        if (successCounter < 3)
        {
            successCounter += 1;
        }
        //if successCounter reaches 3, spawnPaperWork and lock this station
        else if (successCounter == 3)
        {
            successCounter = 0;

            SpawnPaperWork();
            LockStation();

            successCounter += 1;
        }
    }
    public void SpawnPaperWork()
    {
        //randomize target station for spawned document, while target is this station, randomize again
        do
        {
            targetStation = (Station)Random.Range(0, System.Enum.GetValues(typeof(Station)).Length - 1);
        }
        while (currentStation == targetStation);
        //initiate a new document with the new target
        GameObject NewDocument = Instantiate(documents, docSpawnPoint);
        NewDocument.GetComponent<Document>().SetDestinationStation(targetStation);

        //listen to HandIn
        NewDocument.GetComponent<Document>().HandIn += UnLockStation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Document>().targetStation == currentStation)
        {
            other.GetComponent<Document>().DeliverDocument();
            UnLockStation();
        }
    }

    public void LockStation()
    {
        myStation.locked = true;
    }

    public void UnLockStation()
    {
        myStation.locked = false;
    }
}
