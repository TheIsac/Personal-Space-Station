using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAlarm : MonoBehaviour {

    [SerializeField]
    private GameObject station;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        station.GetComponent<Interactable>().OnStationFailure += OnEngineFailure;
        station.GetComponent<Interactable>().OnStationFixed += OnEngineFixed;
    }

    void OnEngineFailure()
    {
        ActivateAlarm();
    }

    void OnEngineFixed()
    {
        DeactivateAlarm();
    }

    private void ActivateAlarm()
    {
        audioManager.Play("Alarm");
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void DeactivateAlarm()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
