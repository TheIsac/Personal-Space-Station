﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public bool continousUpdate = false;
    public Transform flurp;
    Camera cam;

    // offset in screen points
    Vector3 flurpPopupOffset = Vector3.up * 40 + Vector3.right * 20;

    void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if(continousUpdate)
        {
            transform.rotation = Camera.main.transform.rotation;

            if (flurp != null)
            {
                // Find flurps position i screen space, add the offset and then tranlsate the result back to world point
                transform.position = cam.ScreenToWorldPoint(cam.WorldToScreenPoint(flurp.position) + flurpPopupOffset);
            }
        }
    }
}
