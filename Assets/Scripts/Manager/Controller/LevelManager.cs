using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelUnlock { get; private set; }
    public GameObject[] levelsBtn;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("LevelUnlock")) levelUnlock = PlayerPrefs.GetInt("LevelUnlock");
        else levelUnlock = 1;
    }
    void Start()
    {
        for (int i = 0; i < levelsBtn.Length; i++)
        {
            Transform lockPanel = levelsBtn[i].transform.Find("LvLockPanel");
            if (levelUnlock <= i)
            {
                lockPanel.gameObject.SetActive(true);
                levelsBtn[i].GetComponent<Button>().enabled = false;
            }
            else
            {
                lockPanel.gameObject.SetActive(false);
                levelsBtn[i].GetComponent<Button>().enabled = true;
            }
        }
    }
}
