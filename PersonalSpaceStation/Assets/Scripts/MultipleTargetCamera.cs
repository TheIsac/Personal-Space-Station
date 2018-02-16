using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    private GameObject[] targetPlayers;

    void Start()
    {
        cam = GetComponent<Camera>();

        targetPlayers = GameObject.FindGameObjectsWithTag("CameraTarget");
        Debug.Log("targetPlayers for camera: "+ targetPlayers.Length);
    }

    void LateUpdate()
    {
        if (targetPlayers.Length == 0)
        
            return;
        Move();
        Zoom();


    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / 50f);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }


    void Move()
    {
        Vector3 centerpoint = GetCenterPoint();

        Vector3 newPosition = centerpoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targetPlayers[0].transform.position, Vector3.zero);
        for (int i = 0; i < targetPlayers.Length; i++)
        {
            bounds.Encapsulate(targetPlayers[i].transform.position);
        }

        return bounds.size.x;
    }
    //gets the position of the players and finds the middle point of them to keep the camera in the center of them and keep every character in the range of the camera
    Vector3 GetCenterPoint()
    {
        if (targetPlayers.Length == 1)
        {
            return targetPlayers[0].transform.position;
        }
        var bounds = new Bounds(targetPlayers[0].transform.position, Vector3.zero);
        for (int i = 0; i < targetPlayers.Length; i++)
        {
            bounds.Encapsulate(targetPlayers[i].transform.position);
        }
        return bounds.center;
    }
}
