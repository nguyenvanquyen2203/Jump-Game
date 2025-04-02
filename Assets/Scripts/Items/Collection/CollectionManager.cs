using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private static CollectionManager instance;
    public static CollectionManager Instance { get { return instance; } }
    public PoolCtrl itemCollect;
    public PoolCtrl boxBreakCtrl;
    public PoolCtrl pieceBreakCtrl;
    public PoolCtrl beePieceBreakCtrl;
    public PoolCtrl buffJumpCtrl;
    private void Awake()
    {
        instance = this;
    }
    public void ActivePoolCtrl(PoolCtrl poolCtrl, Vector3 itemPos)
    {
        poolCtrl.ActivePool(itemPos);
    }
}
