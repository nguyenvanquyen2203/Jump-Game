using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    public string spawnTag;
    public int numberSpawnObj;
    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();
    private void Reset()
    {
        spawnTag = "Monster";
        foreach (Transform child in transform)
        {
            if (child.CompareTag(spawnTag))
            {
                spawnObjects.Add(child.gameObject);
            }
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < numberSpawnObj; i++)
        {
            spawnObjects[(int)(Random.value * (spawnObjects.Count - 1))].SetActive(true);
        }
    }
    private void Awake()
    {
        //Reset();
    }
    private void Start()
    {
        foreach (GameObject spawnObject in spawnObjects)
        {
            spawnObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        foreach (GameObject spawnObject in spawnObjects) spawnObject.SetActive(false);
    }
}
