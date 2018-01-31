using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {
    public Station station;
    Bounds bounds;

    private void Start()
    {
        bounds = GetComponent<BoxCollider>().bounds;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, bounds.size);
    }

    private void OnTriggerEnter(Collider other)
    {
        HeatController heat = other.GetComponentInParent<HeatController>();

        if (heat == null)
        {
            return;
        }

        heat.SetCurrentStation(station);
    }

    private void OnTriggerExit(Collider other)
    {
        HeatController heat = other.GetComponentInParent<HeatController>();

        if (heat == null)
        {
            return;
        }

        heat.SetCurrentStation(Station.None);
    }
}
