using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject player;
    private Vector3 currentPos;
    private Quaternion currentQuat;

    [HideInInspector] public Color cubeColor;

    void Start()
    {
        currentPos = gameObject.transform.position;
        currentQuat = Quaternion.Euler(0, 0, 0);

        if (player != null)
        {
            Instantiate(player, currentPos, currentQuat);
        }
    }

    public void OnDrawGizmos()
    {
        GetComponent<SpawnerEditor>
        if(cubeColor != null)
        {
            Gizmos.color = cubeColor;
            Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        }
    }
}
