using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image playerIcon;
    [SerializeField] private TextMeshProUGUI coinTxt;
    void Start()
    {
        GameManager.Instance.AddCoinCollectEvent(UpdateCoin);
        playerIcon.sprite = PlayerData.Instance.GetCharacter().characterSprite;
    }
    public void UpdateCoin()
    {
        coinTxt.text = GameManager.Instance.GetCoin().ToString();
    }
}
