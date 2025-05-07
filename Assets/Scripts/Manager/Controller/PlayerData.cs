using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public static PlayerData Instance {  get { return instance; } }
    public CharacterDB characterDB;
    private CharacterData characterData;
    private SkinData skinData;
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        characterData = LoadData<CharacterData>(Application.dataPath + "/PlayerData.txt");
        skinData = LoadData<SkinData>(Application.dataPath + "/SkinData.txt");
    }
    public List<Character> GetCharacters()
    {
        List<Character> characters = new List<Character>();
        //foreach (var character in characterDB.characters) characters.Add(character);
        foreach (var character in characterDB.characters) characters.Add(character);
        return characters;
    }
    public void Save<T>(T data, string path)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
    public T LoadData<T>(string path) 
    {
        if (!File.Exists(path))
        {
            Debug.Log("Don't exists save.txt");
            //return null;
        }
        string saveString = File.ReadAllText(path);
        T data = JsonUtility.FromJson<T>(saveString);
        return data;
    }
    public int GetIndexSkin() => characterData.indexSkin;
    public void SetIndexSkin(int index) => characterData.indexSkin = index;
    public void BuySkin(int index)
    {
        //characterDB.BuySkin(index);
        characterData.coin -= skinData.coinsSkin[index];
        skinData.coinsSkin[index] = 0;
        Save<CharacterData>(characterData, Application.dataPath + "/PlayerData.txt");
        Save<SkinData>(skinData, Application.dataPath + "/SkinData.txt");
    }
    public int GetPrice(int index) => skinData.coinsSkin[index];
    public AnimatorOverrideController GetAnimator() => characterDB.GetAnimator(characterData.indexSkin);
    public Character GetCharacter() => characterDB.GetCurrentCharacter(characterData.indexSkin);
    public int GetCoin() => characterData.coin;
    public void SaveCoin(int coin) => characterData.coin = coin;
    public void CollectCoin(int coin)
    {
        characterData.coin += coin;
        Save<CharacterData>(characterData, Application.dataPath + "/PlayerData.txt");
        
    } 
}
[Serializable] 
public class CharacterData
{
    public int indexSkin;
    public int coin;
}
[Serializable]
public class SkinData
{
    public int[] coinsSkin;
}