using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinSell : MonoBehaviour
{
    private CoinManager manager;
    private string fruitName;
    public Image fruitImage;
    public TextMeshProUGUI fruitText;
    public MyButton sellBtn;
    private int fruitVal;
    private int numberFruit;
    public void Intinialize(CoinManager _manager, string _fruitName, Sprite _fruitImage, int val)
    {
        this.manager = _manager;
        this.fruitName = _fruitName;
        this.fruitImage.sprite = _fruitImage;
        this.fruitVal = val;
        sellBtn.SetText(fruitVal.ToString());
        numberFruit = PlayerPrefs.GetInt(fruitName, 0);
        UpdateUI();

    }
    private void OnEnable()
    {
        numberFruit = PlayerPrefs.GetInt(fruitName, 0);
        UpdateUI();
    }
    public void SellAction()
    {
        numberFruit--;
        manager.AddCoin(fruitVal);
        UpdateUI();
    }
    private void UpdateUI()
    {   
        fruitText.text = numberFruit.ToString();
        if (numberFruit <= 0) sellBtn.SetInteractable(false);
        else sellBtn.SetInteractable(true);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(fruitName, numberFruit);
    }
}
