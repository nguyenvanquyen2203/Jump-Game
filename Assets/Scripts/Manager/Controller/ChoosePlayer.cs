using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    private int selectedIndex = 0;
    public Image characterImg;
    public TextMeshProUGUI characterText;
    public CharacterDB characterDB;
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
}
