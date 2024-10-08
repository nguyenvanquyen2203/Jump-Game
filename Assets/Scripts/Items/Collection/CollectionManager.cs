using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private static CollectionManager instance;
    public static CollectionManager Instance { get { return instance; } }
    public PoolCtrl fruitCollect;
    public PoolCtrl boxBreakCtrl;
    private void Awake()
    {
        instance = this;
    }
    public void ActiveFruitCollection(Vector3 itemPos)
    {
        fruitCollect.ActivePool(itemPos);
    }
    public void ActiveBoxBreak(Vector3 itemPos)
    {
        boxBreakCtrl.ActivePool(itemPos);
    }
}
