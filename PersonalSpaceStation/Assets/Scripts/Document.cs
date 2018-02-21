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
    }

    public void SetDestinationStation(Station destinationStation)
    {
        targetStation = destinationStation;

        switch (targetStation)
        {
            case Station.EngineRoom:
                spriteRenderer.sprite = engineRoomIcon;
                break;
            case Station.AtmoRoom:
                spriteRenderer.sprite = atmoRoomIcon;
                break;
            case Station.PlantRoom:
                spriteRenderer.sprite = plantRoomIcon;
                break;
            case Station.WaterPumps:
                spriteRenderer.sprite = pumpRoomIcon;
                break;
            default:
                //documentMaterial.color = Color.black;
                break;
        }
        //spriteRenderer.gameObject.SetActive(true);
    }

    public void DeliverDocument()
    {
        if (HandIn != null)
        {
            HandIn.Invoke();
            AudioManager.instance.Play("Pling");
            Destroy(gameObject);
        }
    }
}
