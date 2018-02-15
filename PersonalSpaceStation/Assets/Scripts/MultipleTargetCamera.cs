using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = .5f;

    private Vector3 velocity;
    private Vector3 cameraTarget;
    public Vector3 offset;

    private Transform target;

    void Start()
    {
        //targets = GameObject.FindGameObjectWithTag("Player").transform;
        //cameraTarget = new Vector3(targets.position.x, transform.position.y, target.position.z);
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Vector3 centerpoint = GetCenterPoint();

        Vector3 newPosition = centerpoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    //gets the position of the players and finds the middle point of them to keep the camera in the center of them and keep every character in the range of the camera
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
