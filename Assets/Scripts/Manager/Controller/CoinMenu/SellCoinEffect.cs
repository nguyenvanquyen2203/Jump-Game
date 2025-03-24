using TMPro;
using UnityEngine;

public class SellCoinEffect : MonoBehaviour
{
    private CoinManager coinManager;
    private TextMeshProUGUI txt;
    private Color color;
    private Color noneColor;
    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
        color = txt.color;
        noneColor = txt.color;
        noneColor.a = 0;
    }
    public void Intinial(CoinManager manager)
    {
        this.coinManager = manager;
    }
    public void ActiveTxt(string coinValue)
    {
        gameObject.SetActive(true);
        color.a = 1f;
        txt.color = color;
        txt.text = "+ " + coinValue;
        LeanTween.value(gameObject, (value) => { txt.color = value; }, txt.color, noneColor, 1).setEase(LeanTweenType.easeOutQuad).setOnComplete(() => { 
            coinManager.AddTxt(this);
            gameObject.SetActive(false); 
        });
    }
    
}
