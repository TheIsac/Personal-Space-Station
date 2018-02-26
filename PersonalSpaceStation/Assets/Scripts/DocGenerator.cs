using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocGenerator : MonoBehaviour {

    //Variables and GameObjects for setting up the required fields for the documents. 
    public Station currentStation;
    public Station targetStation;

    public int successCounter = 0;
    public int documentsWaitingForHandin = 0;

    public GameObject documents;
    public Transform docSpawnPoint;

    //public Document document;

    public Interactable myStation;

    public GameObject deskLamp1;
    public GameObject deskLamp2;
    public GameObject deskLamp3;

    // Use this for initialization
    void Start ()
    {
        TurnOffDeskLamps();
    }

    public void AddDocumentForhandin()
    {
        documentsWaitingForHandin++;
    }

    public void RemoveDocumentForhandin()
    {
        documentsWaitingForHandin--;

        if (documentsWaitingForHandin < 0)
            documentsWaitingForHandin = 0;
    }


    //recieve signal from Interactable, that a station was fixed and count the success
    public void DocumentGenerator()
    {
        successCounter++;

        TurnOnDeskLamp(successCounter);

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
        Document NewDocument = Instantiate(documents, docSpawnPoint).GetComponent<Document>();
        NewDocument.SetDestinationStation(targetStation);

        NewDocument.spawnWorkbench = this;

        //listen to HandIn
        NewDocument.HandIn += UnLockStation;

        //// Activate hand in icon
        GameManager.instance.ToggleHandInUI(targetStation, true);
    }

    //If the document is taken to the right part of the ship, it is delivered. 
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("niklas was here");
        Document carriedDoc = other.GetComponentInParent<Document>();


        if (carriedDoc == null || other.tag != "DocumentHandIn")
            return;

        if (carriedDoc.targetStation == currentStation)
        {
            GameManager.instance.ToggleHandInUI(carriedDoc.targetStation, false);
            carriedDoc.DeliverDocument();

            carriedDoc.spawnWorkbench.TurnOffDeskLamps();
        }
    }

    //Lock the station if a document is spawned.
    public void LockStation()
    {
        myStation.locked = true;
    }

    //unlocks the station if the document has been delivered.
    public void UnLockStation()
    {
        myStation.locked = false;
    }

    void TurnOffDeskLamps()
    {
        deskLamp1.SetActive(false);
        deskLamp2.SetActive(false);
        deskLamp3.SetActive(false);
    }

    void TurnOnDeskLamp(int count)
    {
        if (count == 1)
        {
            deskLamp1.SetActive(true);
        }
        if (count == 2)
        {
            deskLamp2.SetActive(true);
        }
        if (count == 3)
        {
            deskLamp3.SetActive(true);
        }
    }
}
