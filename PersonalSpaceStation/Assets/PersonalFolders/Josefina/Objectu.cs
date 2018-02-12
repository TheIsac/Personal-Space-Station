using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public CharacterSelection player;
    public GameObject[] characterModels;
}