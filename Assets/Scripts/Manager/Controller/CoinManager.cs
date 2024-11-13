using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI bananaCoin;
    public TextMeshProUGUI appleCoin;
    public TextMeshProUGUI melonCoin;
    public TextMeshProUGUI coinTxt;
    private int banana;
    private int apple;
    private int melon;
    private int coin;
    // Start is called before the first frame update
    void Awake()
    {
        banana = PlayerPrefs.GetInt("Banana", 0);
        apple = PlayerPrefs.GetInt("Apple", 0);
        melon = PlayerPrefs.GetInt("Melon", 0);
        coin = PlayerPrefs.GetInt("Coin", 0);
    }
    private void OnEnable()
    {
        bananaCoin.text = banana.ToString();
        appleCoin.text = apple.ToString();
        melonCoin.text = melon.ToString();
        coinTxt.text = coin.ToString();
    }
    public void SellFruit(string nameFruit)
    {
        switch (nameFruit)
        {
            case "Banana":
                if (banana <= 0) break;
                banana--;
                coin += 1;
                break;
            case "Apple":
                if (apple <= 0) break;
                apple--;
                coin += 2;
                break;
            case "Melon":
                if (melon <= 0) break;
                melon--;
                coin += 5;
                break;
        }
        Save();
        UpdateUI();
    }
    private void UpdateUI()
    {
        bananaCoin.text = banana.ToString();
        appleCoin.text = apple.ToString();
        melonCoin.text = melon.ToString();
        coinTxt.text = coin.ToString();
    }
    private void Save()
    {
        PlayerPrefs.SetInt("Banana", banana);
        PlayerPrefs.SetInt("Apple", apple);
        PlayerPrefs.SetInt("Melon", melon);
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
}
