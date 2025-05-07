using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private GameObject playerObj;
    public Transform spawnPoint;
    private int star = 0;
    private int coin = 0;
    [SerializeField] private FakePlayer fakePlayer;
    private int levelUnlock;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private UnityEvent collectCoinEvt = new UnityEvent();
    private void Awake()
    {
        instance = this;
    }
    private void Reset()
    {
        spawnPoint = GameObject.Find("Start").transform;
        fakePlayer = GameObject.Find("FakePlayer").GetComponent<FakePlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint == null || fakePlayer == null) Reset(); 
        AudioManager.Instance.PlayMusic("Background");
        levelUnlock = LevelManager.Instance.GetUnlockLV();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.transform.position = spawnPoint.position;
        InputCtrl.Instance.EnableInput();
    }
    public void Death()
    {
        collectCoinEvt.RemoveAllListeners();
        playerObj.SetActive(false);
        fakePlayer.Disappear(playerObj.transform);
        Invoke(nameof(Appear), 2f);
    }
    public void GameOver(bool isWin)
    {
        InputCtrl.Instance.DisableInput();
        if (isWin)
        {
            AudioManager.Instance.PlaySFX("WinGame");
            if (LevelManager.Instance.GetCurrentLV() == levelUnlock) LevelManager.Instance.UnlockLv();
            LevelManager.Instance.SetStar(star);
        }
        else AudioManager.Instance.PlaySFX("GameOver");
        PlayerData.Instance.CollectCoin(coin);
        playerObj.SetActive(isWin);
        GameMenuCtrl.Instance.GameOver(isWin);
    }
    public void Appear()
    {
        fakePlayer.Appear(spawnPoint);
        playerObj.transform.position = spawnPoint.transform.position;
    }
    public void SpawnPlayer()
    {
        playerObj.SetActive(true);
    }
    public void UpdateSpawnPoint(Transform _spawnPoint)
    {
        spawnPoint = _spawnPoint;
    }
    public void CollectStar() => star++;
    public int GetStar() => star;
    public int GetCoin() => coin;

    public void CollectCoin()
    {
        coin++;
        collectCoinEvt?.Invoke();
    }
    public void AddCoinCollectEvent(UnityAction act)
    {
        collectCoinEvt.AddListener(act);
    }
}