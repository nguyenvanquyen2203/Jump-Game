using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    public void ActivePool(Vector3 activePos)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
    }
    public void DisablePool()
    {
        gameObject.SetActive(false);
    }
}
