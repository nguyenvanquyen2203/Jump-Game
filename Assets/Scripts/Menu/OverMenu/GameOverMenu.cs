using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Image bG;
    public GameObject overMenu;
    public GameObject lockPanel;
    private void Start()
    {
        bG.color = SomeColor.black(0);
        overMenu.transform.localScale = Vector2.zero;
        overMenu.SetActive(false);
    }
    public void GameOver(bool _isWin)
    {
        OpenMenu();
        lockPanel.SetActive(!_isWin);
    }
    public void OpenMenu()
    {
        overMenu.SetActive(true);
        AppearMenu();
    }
    private void AppearMenu()
    {
        LeanTween.value(gameObject, (value) => { bG.color = value; }, SomeColor.black(0), SomeColor.black(.5f), .8f).setEase(LeanTweenType.easeOutQuad).setIgnoreTimeScale(true);
        overMenu.LeanScale(Vector2.one, .8f).setIgnoreTimeScale(true);
    }
}
