using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject player;
    private Vector3 currentPos;
    private Quaternion currentQuat;

    [HideInInspector] public int index;

    [HideInInspector] public Color cubeColor;

    private void Awake()
    {
        CheckSettings(index);
    }

    void CheckSettings(int index)
    {
        switch (index)
        {
            case 0:
                player.GetComponent<Movement>().player = "_P1";
                break;
            case 1:
                player.GetComponent<Movement>().player = "_P2";
                break;
            case 2:
                player.GetComponent<Movement>().player = "_P3";
                break;
            case 3:
                player.GetComponent<Movement>().player = "_P4";
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }

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
        switch (index)
        {
            case 0:
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
                break;
            case 1:
                Gizmos.color = new Color(0, 1, 0, 0.5f);
                Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
                break;
            case 2:
                Gizmos.color = new Color(0, 0, 1, 0.5f);
                Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
                break;
            case 3:
                Gizmos.color = new Color(1, 1, 0, 0.5f);
                Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
}
