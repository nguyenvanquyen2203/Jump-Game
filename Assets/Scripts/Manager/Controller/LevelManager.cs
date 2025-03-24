using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelUnlock { get; private set; }
    public Button[] levelsBtn;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("LevelUnlock")) levelUnlock = PlayerPrefs.GetInt("LevelUnlock");
        else levelUnlock = 1;
        levelUnlock = 1;
    }
    void Start()
    {
        for (int i = 0; i < levelsBtn.Length; i++)
        {
            if (levelUnlock <= i)
            {
                levelsBtn[i].GetComponent<Image>().color = new Color(255, 255, 255, 128);
                levelsBtn[i].interactable = false;
            }
            else
            {
                levelsBtn[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                levelsBtn[i].interactable= true;
            }
        }
    }
}
