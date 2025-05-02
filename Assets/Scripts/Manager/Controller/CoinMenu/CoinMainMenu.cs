using TMPro;
using UnityEngine;

public class CoinMainMenu : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;

    private int coin;
    // Start is called before the first frame update
    void Awake()
    {
        coin = PlayerData.Instance.GetCoin();
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
        PlayerData.Instance.SaveCoin(coin);
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