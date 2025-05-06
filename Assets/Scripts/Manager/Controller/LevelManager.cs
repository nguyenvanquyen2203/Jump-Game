using System;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public LevelDB levelDB;
    private LevelData levelData;
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
    private void Start()
    {
        LoadData();
        /*levelData = new LevelData(levelDB);
        Save();*/
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(levelData);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.dataPath + "/save.txt"))
        {
            Debug.Log("Don't exists save.txt");
            return;
        }
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        levelData = JsonUtility.FromJson<LevelData>(saveString);
    }
    public int GetUnlockLV() => levelData.unlockLV;
    public int GetStarLv(int lv) => levelData.GetStar(lv);
    public void SetCurrentLV(int lv) => levelData.currentLV = lv;
    public int GetCurrentLV() => levelData.currentLV;
    public void UnlockLv() => levelData.unlockLV++;
    public void SetStar(int star)
    {
        levelData.SetStar(star);
        Save();
    }
    public void ReloadLV() => SceneInteractable.LoadScene(GetCurrentLV());
    public void LoadNextLV() => SceneInteractable.LoadScene(GetCurrentLV() + 1);
}

[System.Serializable]
public class LevelData
{
    public int unlockLV;
    public int currentLV;
    public LevelInfo[] levels;
    public int GetStar(int lv) => levels[lv - 1].star;
    public int SetStar(int star) => levels[currentLV - 1].star = Math.Max(star, levels[currentLV - 1].star);
    public LevelData(LevelDB db)
    {
        unlockLV = db.UnlockLV; currentLV = db.CurrentLV;
        levels = new LevelInfo[db.levels.Length];
        for (int i = 0; i < levels.Length; i++) levels[i] = new LevelInfo(db.GetStar(i + 1));
    }
}
[Serializable]
public class LevelInfo
{
    public int star;
    public LevelInfo(int star) => this.star = star;
}