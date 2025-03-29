using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    private int selectedIndex = 0;
    private CoinManager coinManager;
    public Image characterImg;
    public TextMeshProUGUI characterText;
    public CharacterDB characterDB;
    public Button chooseBtn;
    public Button buyBtn;
    private void Awake()
    {
        coinManager = GetComponent<CoinManager>();
    }
    private void Start()
    {
        selectedIndex = characterDB.indexSkin;
        UpdateCharacter(selectedIndex);
    }
    private void UpdateCharacter(int _selectedIndex)
    {
        characterImg.sprite = characterDB.GetCharacter(_selectedIndex).characterSprite;
        characterText.text = characterDB.GetCharacter(selectedIndex).characterName;
        UpdateCharacterAction();
    }
    public void NextPlayer()
    {
        selectedIndex++;
        if (selectedIndex >= characterDB.CharacterCount) selectedIndex = 0;
        UpdateCharacter(selectedIndex);
    }

    public void BackPlayer()
    {
        selectedIndex--;
        if (selectedIndex < 0) selectedIndex = characterDB.CharacterCount - 1;
        UpdateCharacter(selectedIndex);
    }
    public void ChooseSkin() => Save();
    private void Save() => characterDB.indexSkin = selectedIndex;
    public void BuySkin()
    {
        int price = characterDB.GetCharacter(selectedIndex).price;
        if (!coinManager.SpendCoin(price)) return;
        characterDB.BuySkin(selectedIndex);
        UpdateCharacter(selectedIndex);
        UpdateCharacterAction();
    }
    private void UpdateCharacterAction()
    {
        int priceSkin = characterDB.GetCharacter(selectedIndex).price;
        chooseBtn.interactable = priceSkin <= 0;
        if (priceSkin <= 0)
        {
            buyBtn.gameObject.SetActive(false);
            chooseBtn.gameObject.SetActive(true);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            characterText.text = "- " + priceSkin;
            buyBtn.interactable = coinManager.GetCoin() >= priceSkin;
        }
    }
}
