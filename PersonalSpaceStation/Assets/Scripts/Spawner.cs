using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Drag the character prefab into the 'Character' bar.
/// Select the player you want to spawn in the drop-down menu.
/// </summary>
public class Spawner : MonoBehaviour
{
    public enum OptionEnum { P1, P2, P3, P4 };
    public OptionEnum player;

    public GameObject character;
    private GameObject spawnedCharacter;
    private Vector3 currentPos;
    private Quaternion currentQuat;


    private int index;

    void Start()
    {
        spawnedCharacter = character;
        currentPos = gameObject.transform.position;
        currentQuat = Quaternion.Euler(0, 0, 0);
        spawnedCharacter = Instantiate(character, currentPos, currentQuat);

        CharacterSpawn();

    }

    void CharacterSpawn()
    {
        switch (player)
        {
            case OptionEnum.P1:
                spawnedCharacter.GetComponent<Movement>().player = "_P1";
                break;
            case OptionEnum.P2:
                spawnedCharacter.GetComponent<Movement>().player = "_P2";
                break;
            case OptionEnum.P3:
                spawnedCharacter.GetComponent<Movement>().player = "_P3";
                break;
            case OptionEnum.P4:
                spawnedCharacter.GetComponent<Movement>().player = "_P4";
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }

    //Draws the cube in the editor.
    public void OnDrawGizmos()
    {
        switch (player)
        {
            case OptionEnum.P1:
                //spawnedCharacter.GetComponent<Movement>().player = "_P1";
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;
            case OptionEnum.P2:
                //spawnedCharacter.GetComponent<Movement>().player = "_P2";
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;
            case OptionEnum.P3:
                //spawnedCharacter.GetComponent<Movement>().player = "_P3";
                Gizmos.color = Color.green;
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;
            case OptionEnum.P4:
                //spawnedCharacter.GetComponent<Movement>().player = "_P4";
                Gizmos.color = Color.yellow;
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
}
