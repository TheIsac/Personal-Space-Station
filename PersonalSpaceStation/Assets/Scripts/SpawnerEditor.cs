using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    string[] options = new string[] { "P1", "P2", "P3", "P4", };
    public int index = 0;

    public override void OnInspectorGUI()
    {
        index = EditorGUILayout.Popup("Player", index, options);
    }
}
