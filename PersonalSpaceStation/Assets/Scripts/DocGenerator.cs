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

        successCounter++;

        if(successCounter >= 3)
        {
            SpawnPaperWork();
            LockStation();

            successCounter = 0;
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

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("niklas was here");
        Document carriedDoc = other.GetComponent<Document>();


        if (carriedDoc == null)
            return;

        if (carriedDoc.targetStation == currentStation)
        {
            Debug.Log("delivered!");
            carriedDoc.DeliverDocument();
            UnLockStation();
            //Destroy(gameObject);
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
