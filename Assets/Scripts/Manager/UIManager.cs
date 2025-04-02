using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image playerIcon;
    // Start is called before the first frame update
    void Start()
    {
        playerIcon.sprite = SkinManager.Instance.GetCharacter().characterSprite;
    }
}
