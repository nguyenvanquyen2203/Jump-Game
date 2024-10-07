using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image playerIcon;
    public CharacterDB characterDB;
    // Start is called before the first frame update
    void Start()
    {
        playerIcon.sprite = characterDB.GetCharacter(GetCharacterIndex()).characterSprite;
    }
    public int GetCharacterIndex()
    {
        if (!PlayerPrefs.HasKey("selectedIndex")) return 0;
        return PlayerPrefs.GetInt("selectedIndex");
    }
}
