using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private static CollectionManager instance;
    public static CollectionManager Instance { get { return instance; } }
    public PoolCtrl fruitCollect;
    private void Awake()
    {
        instance = this;
    }
    public void Active(Vector3 itemPos)
    {
        fruitCollect.ActivePool(itemPos);
    }
}
