using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject player;
    private Vector3 currentPos;
    private Quaternion currentQuat;

    void Start()
    {

        currentPos = gameObject.transform.position;
        currentQuat = Quaternion.Euler(0, 0, 0);

        if (player != null)
        {
            Instantiate(player, currentPos, currentQuat);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
