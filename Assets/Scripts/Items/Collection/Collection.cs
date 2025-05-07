using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : PoolObj
{ 
    public void Active(Vector3 itemPos)
    {
        transform.position = itemPos;
        gameObject.SetActive(true);
    }
    public void OnDisable() => gameObject.SetActive(false);
}
