using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchGizmo : MonoBehaviour {

    public Color gizmoColor;
    public BoxCollider boxCollider;

    public GameObject dropOfZone;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponentInParent<BoxCollider>();
    }

    public void OnDrawGizmos()
    {
        gizmoColor = new Color(0f, 1f, 1f, 0.3f);
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position + boxCollider.center, transform.localScale);
    }

}

