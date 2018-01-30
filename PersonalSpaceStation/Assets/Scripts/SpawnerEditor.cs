using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public string[] options = new string[] { "P1", "P2", "P3", "P4", };
    public GameObject player;

    private int index;

    public override void OnInspectorGUI()
    {
        Spawner spawnerScript = (Spawner)target;

        //Declaration
        index = spawnerScript.index;
        player = spawnerScript.player;

        //The visuals in the inspector.
        player = (GameObject)EditorGUILayout.ObjectField(player, typeof(Object), true);
        index = EditorGUILayout.Popup("Player", index, options);

        if (player != spawnerScript.player)
            spawnerScript.player = player;

        //Switch telling 'Spawner' what option is selected.
        switch (index)
        {
            case 0:
                spawnerScript.index = 0;
                SceneView.RepaintAll();
                break;
            case 1:
                spawnerScript.index = 1;
                SceneView.RepaintAll();
                break;
            case 2:
                spawnerScript.index = 2;
                SceneView.RepaintAll();
                break;
            case 3:
                spawnerScript.index = 3;
                SceneView.RepaintAll();
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
}
