using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonnaTrySomethingDontTouch : MonoBehaviour {

    
    public float smoothTime = .5f;

    private Vector3 cameraTarget;
    private Vector3 velocity;
    private Vector3 offset;

    private Transform targets;

	// Use this for initialization
	void Start () {
        targets = GameObject.FindGameObjectsWithTag("Player").transform;
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(targets.Count == 0)
        {
            return;
        }
        cameraTarget = new Vector3(targets.position.x, transform.position.y, targets.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);

        Vector3 centerpoint = GetCenterPoint();

        Vector3 newPosition = centerpoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

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
