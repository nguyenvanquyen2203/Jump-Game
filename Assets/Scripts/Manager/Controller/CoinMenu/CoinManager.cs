using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public FruitsDatabase fruitsDatabase;
    private List<CoinSell> coinSells = new List<CoinSell>();
    public TextMeshProUGUI coinTxt;

    [SerializeField] private int numberTextPool;
    public SellCoinEffect coinSellTxt;
    Queue<SellCoinEffect> coinTxts = new Queue<SellCoinEffect>();

    private int coin;
    // Start is called before the first frame update
    void Awake()
    {
        GetAllCoinSells();
        CreateCoinEffectPool(numberTextPool);
        coin = PlayerPrefs.GetInt("Coin", 0);
    }
    #region Coin Effect Pool
    private void CreateCoinEffectPool(int numberPool)
    {
        for (int i = 0; i < numberPool; i++)
        {
            SellCoinEffect txt = Instantiate(coinSellTxt, transform);
            txt.Intinial(this);
            coinSellTxt.gameObject.SetActive(false);
            coinTxts.Enqueue(txt);
        }
    }
    public SellCoinEffect GetCoinTxt() => coinTxts.Dequeue();
    public void AddTxt(SellCoinEffect txt) => coinTxts.Enqueue(txt);
    public void ShowCoinEffect(Transform _t)
    {
        SellCoinEffect coin = GetCoinTxt();
        coin.ActiveTxt("10");
        coin.transform.position = _t.position;
    }
    #endregion
    private void OnEnable()
    {
        for (int i = 0; i < coinSells.Count; i++)
        {
            Fruit fruit = fruitsDatabase.fruits[i];
            coinSells[i].Intinialize(this, fruit.fruitName, fruit.image, fruit.value);
        }
        coinTxt.text = coin.ToString();
    }
    public void SellFruit(string nameFruit)
    {
        int changeCoin = 0;
        coin += changeCoin;
        SellCoinEffect coinUI = GetCoinTxt();
        coinUI.ActiveTxt(changeCoin.ToString());
        coinUI.transform.position = coinTxt.transform.position;
        Save();
        UpdateUI();
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
    private void GetAllCoinSells()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            CoinSell coinSell = transform.GetChild(i).GetComponent<CoinSell>();
            if (coinSell != null) coinSells.Add(coinSell);
        }
    }
    public void AddCoin(int addCoin)
    {
        coin += addCoin;
        UpdateUI();
    }
}