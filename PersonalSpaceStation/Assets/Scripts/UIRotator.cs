using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public bool continousUpdate = false;
    public Transform flurp;
    Camera cam;

    // offset divider, should work with most resolutions
    // offset is 40 pixels in 1920 in x so XOFFSET = 1920/40, 20 pixels in 1080 in y so YOFFSET = 1080/20
    const float XOFFSET = 48;
    const float YOFFSET = 54;

    Vector3 flurpPopupOffset = Vector3.up * (Screen.width / XOFFSET) + Vector3.right * (Screen.height / YOFFSET);

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
                // Find flurps position in screen space, add the offset and then tranlsate the result back to world point
                transform.position = cam.ScreenToWorldPoint(cam.WorldToScreenPoint(flurp.position) + flurpPopupOffset);
            }
        }
    }
}
