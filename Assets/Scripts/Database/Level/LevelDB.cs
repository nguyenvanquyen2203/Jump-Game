using System;
using System.Runtime.Serialization;
using UnityEngine;
[CreateAssetMenu (menuName = "LevelDB", fileName = "LevelDB")]
public class LevelDB : ScriptableObject
{
    [SerializeField] private int unlockLV;
    public int UnlockLV { get { return unlockLV; } set { unlockLV = value; } }
    private int currentLV;
    public int CurrentLV { get { return currentLV; } set { currentLV = value; } }
    public LevelInfo[] levels;
    public int GetStar(int lv) => levels[lv - 1].star;
    public int SetStar(int star) => levels[currentLV - 1].star = Math.Max(star, levels[currentLV - 1].star);
}