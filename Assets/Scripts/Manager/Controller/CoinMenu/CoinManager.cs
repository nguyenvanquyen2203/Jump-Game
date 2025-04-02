using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;

    private int coin;
    // Start is called before the first frame update
    void Awake()
    {
        coin = PlayerPrefs.GetInt("Coin", 200);
        coin = 200;
    }
    private void OnEnable()
    {
        coinTxt.text = coin.ToString();
    }
    private void OnDisable()
    {
        Save();
    }
    private void UpdateUI()
    {
        coinTxt.text = coin.ToString();
    }
    private void Save()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }
    public bool SpendCoin(int price)
    {
        if (coin >= price)
        {
            coin -= price;
            UpdateUI();
            return true;
        }
        else return false;
    }
    public void AddCoin(int addCoin)
    {
        coin += addCoin;
        UpdateUI();
    }
    public int GetCoin() => coin;   
}