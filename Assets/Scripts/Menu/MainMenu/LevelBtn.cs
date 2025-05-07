using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public int level;
    public StarBtnUI star;
    private Button btn;
    public TextMeshProUGUI txt;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(EnterLevel);   
    }
    private void OnEnable()
    {
        if (level <= LevelManager.Instance.GetUnlockLV())
        {
            star.gameObject.SetActive(true);
            star.Show(LevelManager.Instance.GetStarLv(level));
            btn.GetComponent<Image>().color = SomeColor.white(1);
            txt.color = SomeColor.white(1);
            btn.interactable = true;
        }
        else
        {
            star.gameObject.SetActive(false);
            btn.GetComponent<Image>().color = SomeColor.white(.5f);
            txt.color = SomeColor.white(.5f);
            btn.interactable = false;
        }
    }
    private void EnterLevel()
    {
        LevelManager.Instance.SetCurrentLV(level);
        SceneInteractable.LoadScene(level);
    }
}
