using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    private int selectedIndex = 0;
    private CoinMainMenu coinManager;
    public Image characterImg;
    public TextMeshProUGUI characterText;
    private PlayerData skinManager;
    private List<Character> characters = new List<Character>();
    public Button chooseBtn;
    public Button buyBtn;
    private void Awake()
    {
        coinManager = GetComponent<CoinMainMenu>();
    }
    private void Start()
    {
        skinManager = PlayerData.Instance;
        selectedIndex = skinManager.GetIndexSkin();
        characters = skinManager.GetCharacters();
        UpdateCharacter(selectedIndex);
    }
    private void UpdateCharacter(int _selectedIndex)
    {
        characterImg.sprite = characters[selectedIndex].characterSprite;
        characterText.text = characters[selectedIndex].characterName;
        UpdateCharacterAction();
    }
    public void NextPlayer()
    {
        selectedIndex++;
        if (selectedIndex >= characters.Count) selectedIndex = 0;
        UpdateCharacter(selectedIndex);
    }

    public void BackPlayer()
    {
        selectedIndex--;
        if (selectedIndex < 0) selectedIndex = characters.Count - 1;
        UpdateCharacter(selectedIndex);
    }
    public void ChooseSkin() => Save();
    private void Save() => skinManager.SetIndexSkin(selectedIndex);
    public void BuySkin()
    {
        int price = characters[selectedIndex].price;
        if (!coinManager.SpendCoin(price)) return;
        skinManager.BuySkin(selectedIndex);
        UpdateCharacter(selectedIndex);
        UpdateCharacterAction();
    }
    private void UpdateCharacterAction()
    {
        int priceSkin = characters[selectedIndex].price;
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
