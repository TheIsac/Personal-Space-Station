using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {
    public GameObject Player;
    public float repeatTime = 3f;

    void Start()
    {
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        Instantiate(Player, transform.position, Quaternion.identity);
    }
}
