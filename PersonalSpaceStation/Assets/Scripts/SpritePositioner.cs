using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositioner : MonoBehaviour {

    private bool continousUpdate = false;

    void Start()
    {
        transform.position = transform.TransformPoint(0, 2, 0);
    }

    private void LateUpdate()
    {
        if (continousUpdate)
        {
            transform.rotation = Camera.main.transform.rotation;
            transform.position = transform.TransformPoint(0, 2, 0);
        }
    }
}
