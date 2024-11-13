using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    private int selectedIndex = 0;
    private SkinManager skinManager;
    private CoinManager coinManager;
    public Image characterImg;
    public Image lockImg;
    public TextMeshProUGUI characterText;
    public CharacterDB characterDB;
    public Button chooseBtn;
    public Button buyBtn;
    private void Awake()
    {
        skinManager = GetComponent<SkinManager>();
        coinManager = GetComponent<CoinManager>();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedIndex")) selectedIndex = 0;
        else Load();
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
    public void OnDisable() => Save();

    private void Save() => PlayerPrefs.SetInt("selectedIndex", selectedIndex);
    private void Load() => selectedIndex = PlayerPrefs.GetInt("selectedIndex");
    public void BuySkin()
    {
        int price = skinManager.GetPriceSkin(characterDB.GetCharacter(selectedIndex).characterName.Replace(" ", ""));
        if (!coinManager.SpendCoin(price)) return;
        skinManager.BuySkin(characterDB.GetCharacter(selectedIndex).characterName.Replace(" ", ""));
        lockImg.gameObject.SetActive(false);
        UpdateCharacterAction();
    }
    private void UpdateCharacterAction()
    {
        int priceSkin = skinManager.GetPriceSkin(characterDB.GetCharacter(selectedIndex).characterName.Replace(" ", ""));
        if (priceSkin <= 0)
        {
            lockImg.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            chooseBtn.gameObject.SetActive(true);
        }
        else
        {
            lockImg.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "- " + priceSkin;
        }
    }
}
