using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager instance;
    public static MapManager Instance { get { return instance; } }
    public Map[] map1;
    public Map[] map2;
    public Map[] map3;
    
    private int currentMap;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentMap = 0;
        spawnPos = Vector3.zero;
        SpawnMap();
    }
    public void SpawnMap()
    {
        Map map;
        int indexMap = 0;
        switch (currentMap)
        {
            case 0: map = map1[indexMap]; break;
            case 1: map = map2[indexMap]; break;
            default: map = map3[indexMap]; break;
        }
        map.gameObject.SetActive(true);
        map.gameObject.transform.position = spawnPos;
        spawnPos = map.GetSpawnPoint();
        currentMap++;
        if (currentMap >= 3) currentMap = 0;
    }
}
