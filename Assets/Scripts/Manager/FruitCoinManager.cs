using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;

public class FruitCoinManager : MonoBehaviour
{
    private static FruitCoinManager instance;
    public static FruitCoinManager Instance { get { return instance; } }

    public TextMeshProUGUI bananaTxt;
    public TextMeshProUGUI appleTxt;
    public TextMeshProUGUI melonTxt;

    private int bananaMap = 0;
    private int appleMap = 0;
    private int melonMap = 0;

    //FruitCoin
    private int banana;
    private int apple;
    private int melon;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Load();
        UpdateUI();
    }
    public void UpdateFruitCoin()
    {
        Save();
    }
    private void UpdateUI()
    {
        bananaTxt.text = "X " + bananaMap;
        appleTxt.text = "X " + appleMap;
        melonTxt.text = "X " + melonMap;
    }
    public void CollectCoin(string nameFruit)
    {
        switch (nameFruit)
        {
            case "Banana":
                bananaMap++;
                break;
            case "Apple":
                appleMap++;
                break;
            case "Melon":
                melonMap++;
                break;
        }
        UpdateUI();
    } 
    private void Save()
    {
        PlayerPrefs.SetInt("Banana", banana + bananaMap);
        PlayerPrefs.SetInt("Apple", apple + appleMap);
        PlayerPrefs.SetInt("Melon", melon + melonMap);
    }
    private void Load()
    {
        banana = PlayerPrefs.GetInt("Banana", 0);
        apple = PlayerPrefs.GetInt("Apple", 0);
        melon = PlayerPrefs.GetInt("Melon", 0);
    }  
}
