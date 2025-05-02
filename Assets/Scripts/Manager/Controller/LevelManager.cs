using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public LevelDB levelDB;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public int GetUnlockLV() => levelDB.UnlockLV;
    public int GetStarLv(int lv) => levelDB.GetStar(lv);
    public void SetCurrentLV(int lv) => levelDB.CurrentLV = lv;
    public int GetCurrentLV() => levelDB.CurrentLV;
    public void UnlockLv() => levelDB.UnlockLV++;
    public void SetStar(int star) => levelDB.SetStar(star);
    public void ReloadLV() => SceneInteractable.LoadScene(GetCurrentLV());
    public void LoadNextLV() => SceneInteractable.LoadScene(GetCurrentLV() + 1);
}
