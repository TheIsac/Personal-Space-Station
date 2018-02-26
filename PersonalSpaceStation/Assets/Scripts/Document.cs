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

    public DocGenerator spawnWorkbench;

    public Action HandIn;

    public MeshRenderer documnetMesh;

    Material docMat;
    public Material docMatEngine;
    public Material docMatPump;
    public Material docMatAtmo;
    public Material docMatPlant;

    private void Start()
    {
        //docMat = documnetMesh.material;
        //docMat.color = Color.white;
    }

    public void SetDestinationStation(Station destinationStation)
    {
        targetStation = destinationStation;

        switch (targetStation)
        {
            case Station.EngineRoom:
                spriteRenderer.sprite = engineRoomIcon;
                documnetMesh.material = docMatEngine;
                break;
            case Station.AtmoRoom:
                spriteRenderer.sprite = atmoRoomIcon;
                documnetMesh.material = docMatAtmo;
                break;
            case Station.PlantRoom:
                spriteRenderer.sprite = plantRoomIcon;
                documnetMesh.material = docMatPlant;
                break;
            case Station.WaterPumps:
                spriteRenderer.sprite = pumpRoomIcon;
                documnetMesh.material = docMatPump;
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
