using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCtrl : MonoBehaviour
{
    public int numberPool;
    public PoolObj poolObj;
    private List<PoolObj> poolObjs = new List<PoolObj>();
    private void Awake()
    {
        for (int i = 0; i < numberPool; i++)
        {
            PoolObj pool = Instantiate(poolObj, transform);
            poolObjs.Add(pool);
            pool.DisablePool();
        }
    }
    public void ActivePool(Vector3 activePos)
    {
        PoolObj freePool = GetFreePool();
        freePool.ActivePool(activePos);
    }
    private PoolObj GetFreePool()
    {
        foreach (PoolObj poolObj in poolObjs)
        {
            if (!poolObj.gameObject.activeSelf) return poolObj;
        }
        PoolObj pool = Instantiate(poolObj, transform);
        poolObjs.Add(pool);
        return pool;
    }
}
