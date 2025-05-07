using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Image wdBGp;
    public Button[] menuBtns;
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Menu");
    }
    public void OpenPanel(MenuPanel panel)
    {
        foreach (var item in menuBtns)
        {
            item.interactable = false;
        }
        panel.gameObject.SetActive(true);
        LeanTween.value(gameObject, (value) => { wdBGp.color = value; }, SomeColor.black(0), SomeColor.black(.5f), 1).setEase(LeanTweenType.easeOutQuad);
        panel.gameObject.LeanScale(Vector2.one, .8f).setOnComplete(panel.EnableAction);
    }

    public void ClosePanel(MenuPanel panel) 
    {
        LeanTween.value(gameObject, (value) => { wdBGp.color = value; }, SomeColor.black(.5f), SomeColor.black(0f), .7f).setEase(LeanTweenType.easeOutQuad);
        panel.gameObject.LeanScale(Vector2.zero, .5f).setEaseInBack().setOnComplete(() => { 
            panel.gameObject.SetActive(false); 
            panel.DisableAction();
            foreach (var item in menuBtns)
            {
                item.interactable = true;
            }
        });
    }
}
