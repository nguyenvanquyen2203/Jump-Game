using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void SpawnMap(Vector3 spawnPos)
    {
        gameObject.SetActive(true);
        transform.position = spawnPos;
    }
    public Vector3 GetSpawnPoint()
    {
        return transform.Find("SpawnPoint").position;
    }
}
