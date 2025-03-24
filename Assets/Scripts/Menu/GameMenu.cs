using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Image wdBGp;
    private void Awake()
    {
        
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        LeanTween.value(gameObject, (value) => { wdBGp.color = value; }, SomeColor.black(0), SomeColor.black(.5f), 1).setEase(LeanTweenType.easeOutQuad);
        panel.LeanScale(Vector2.one, .8f);
    }

    public void ClosePanel(GameObject panel) 
    {
        LeanTween.value(gameObject, (value) => { wdBGp.color = value; }, SomeColor.black(.5f), SomeColor.black(0f), .7f).setEase(LeanTweenType.easeOutQuad);
        panel.LeanScale(Vector2.zero, .5f).setEaseInBack().setOnComplete(() => { panel.SetActive(false); });
    }
}
