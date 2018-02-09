using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {
    public Station station;
    //Bounds bounds;

    private void Start()
    {
        //bounds = GetComponent<BoxCollider>().bounds;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, bounds.size);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Flurp flurp = other.GetComponentInParent<Flurp>();

        Debug.Log(flurp);

        if (flurp == null)
        {
            return;
        }

        flurp.SetCurrentStation(station);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Flurp flurp = other.GetComponentInParent<Flurp>();

    //    if (flurp == null)
    //    {
    //        return;
    //    }

    //    flurp.SetCurrentStation(Station.None);
    //}
}
