using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private static CollectionManager instance;
    public static CollectionManager Instance { get { return instance; } }
    public enum PoolType
    {
        ItemCollect,
        BoxBreak,
        PlantPiece,
        BeePiece,
        BuffJump,
        Explosion
    }
    public PoolCtrl itemCollect;
    public PoolCtrl boxBreakCtrl;
    public PoolCtrl pieceBreakCtrl;
    public PoolCtrl beePieceBreakCtrl;
    public PoolCtrl buffJumpCtrl;
    public PoolCtrl explosionCtrl;
    private void Awake()
    {
        instance = this;
    }
    public void ActivePoolCtrl(PoolType type, Vector3 itemPos)
    {
        switch (type)
        {
            case PoolType.ItemCollect:
                itemCollect.ActivePool(itemPos);
                break;
            case PoolType.BoxBreak:
                boxBreakCtrl.ActivePool(itemPos);
                break;
            case PoolType.PlantPiece:
                pieceBreakCtrl.ActivePool(itemPos);
                break;
            case PoolType.BeePiece:
                beePieceBreakCtrl.ActivePool(itemPos);
                break;
            case PoolType.BuffJump:
                buffJumpCtrl.ActivePool(itemPos);
                break;
            case PoolType.Explosion:
                explosionCtrl.ActivePool(itemPos);
                break;
            default: 
                break;
        }
    }
}
