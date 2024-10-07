using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCheck : MonoBehaviour
{
    private bool isSpawn;
    private void OnEnable()
    {
        isSpawn = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return; 
        if (!isSpawn)
        {
            MapManager.Instance.SpawnMap();
            isSpawn = true;
        } 
    }
}
