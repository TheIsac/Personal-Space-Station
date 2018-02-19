using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour {

    public Station currentStation;
    public Station targetStation;

    public Sprite engineRoomIcon;
    public Sprite atmoRoomIcon;
    public Sprite plantRoomIcon;
    public Sprite pumpRoomIcon;

    public SpriteRenderer spriteRenderer;

    public Action HandIn;

    Material documentMaterial;

    private void Start()
    {
        documentMaterial = GetComponent<Renderer>().material;
        documentMaterial.color = Color.black;
        spriteRenderer.sprite = plantRoomIcon;
    }

    public void SetDestinationStation(Station destinationStation)
    {
        this.targetStation = destinationStation;
        Debug.Log("Deliver this to "+ targetStation);

        //documentMaterial = GetComponent<Renderer>().material;

        switch (targetStation)
        {
            case Station.EngineRoom:
                documentMaterial.color = Color.black;
                spriteRenderer.sprite = engineRoomIcon;
                break;
            case Station.AtmoRoom:
                documentMaterial.color = Color.black;
                spriteRenderer.sprite = atmoRoomIcon;
                break;
            case Station.PlantRoom:
                documentMaterial.color = Color.black;
                spriteRenderer.sprite = plantRoomIcon;
                break;
            case Station.WaterPumps:
                documentMaterial.color = Color.black;
                spriteRenderer.sprite = pumpRoomIcon;
                break;
            default:
                documentMaterial.color = Color.black;
                break;
        }
        //spriteRenderer.gameObject.SetActive(true);
    }

    public void DeliverDocument()
    {
        if (HandIn != null)
        {
        HandIn.Invoke();
        Destroy(gameObject);
        }
    }
}
