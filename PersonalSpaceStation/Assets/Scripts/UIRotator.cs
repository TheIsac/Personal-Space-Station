using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public bool continousUpdate = false;

    void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void LateUpdate()
    {
        if(continousUpdate)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
