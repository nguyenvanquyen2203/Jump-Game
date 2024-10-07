using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private static CollectionManager instance;
    public static CollectionManager Instance { get { return instance; } }
    [SerializeField] private Collection[] collections;
    // Start is called before the first frame update
    private void Reset()
    {
        collections = GetComponentsInChildren<Collection>();
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (var collection in collections) collection.gameObject.SetActive(false);
    }
    public void Active(Vector3 itemPos)
    {
        foreach (var collection in collections)
        {
            if (!collection.gameObject.activeSelf)
            {
                collection.Active(itemPos);
                return;
            }
        }
    }
}
