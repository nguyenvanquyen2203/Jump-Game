using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public static PlayerData Instance {  get { return instance; } }
    public CharacterDB characterDB;
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public List<Character> GetCharacters()
    {
        List<Character> characters = new List<Character>();
        foreach (var character in characterDB.characters) characters.Add(character);
        return characters;
    }
    public int GetIndexSkin() => characterDB.indexSkin;
    public void SetIndexSkin(int index) => characterDB.indexSkin = index;
    public void BuySkin(int index) => characterDB.BuySkin(index);
    public AnimatorOverrideController GetAnimator() => characterDB.GetAnimator();
    public Character GetCharacter() => characterDB.GetCurrentCharacter();
    public int GetCoin() => characterDB.coin;
    public void SaveCoin(int coin) => characterDB.coin = coin;
    public void CollectCoin(int coin) => characterDB.coin += coin;
}