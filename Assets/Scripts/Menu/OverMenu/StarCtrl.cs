using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarCtrl : MonoBehaviour
{
    [SerializeField] private List<StarEffect> stars;
    public TextMeshProUGUI coinTxt;
    public Text coinText;
    private int star = 0;
    private int indexStar;
    private void OnEnable()
    {
        star = GameManager.Instance.GetStar();
        //coinTxt.text = GameManager.Instance.GetCoin().ToString();
        coinText.text = GameManager.Instance.GetCoin().ToString();
        ShowStar(indexStar);
    }
    public void ShowStar(int number)
    {
        stars[indexStar].gameObject.SetActive(true);
        stars[indexStar].ActiveStar(indexStar < star, this);
    }
    public void ShowNextStar()
    {
        indexStar++;
        if (indexStar >= stars.Count) return;
        stars[indexStar].gameObject.SetActive(true);
        stars[indexStar].ActiveStar(indexStar < star, this);
    }
}
