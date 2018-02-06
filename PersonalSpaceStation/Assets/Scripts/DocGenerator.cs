using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGenerator : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public int successCounter = 0;

    public GameObject documents;
    public Transform docSpawnPoint;

    public Document document;

    public Interactable myStation;

	// Use this for initialization
	void Start () {

        //listen to HandIn
        document.HandIn += UnLockStation;
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
            LockStation();

            successCounter += 1;
        }
    }
    public void SpawnPaperWork()
    {
        do
        {
            targetStation = (Station)Random.Range(0, System.Enum.GetValues(typeof(Station)).Length - 1);
        }
        while (currentStation == targetStation);

        GameObject NewDocument = Instantiate(documents, docSpawnPoint);
        NewDocument.GetComponent<Document>().SetDestinationStation(targetStation);
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
        myStation.inUse = true;
    }

    public void UnLockStation()
    {
        myStation.inUse = false;
    }
}
