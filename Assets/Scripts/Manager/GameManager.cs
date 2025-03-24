using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject fakePlayerObj;
    public GameObject playerObj;
    public Transform spawnPoint;
    [SerializeField] private FakePlayer fakePlayer;
    private int levelUnlock;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("LevelUnlock");
        if (fakePlayer == null)
        {
            fakePlayer = GameObject.Find("FakePlayer")?.GetComponent<FakePlayer>();
            if (fakePlayer == null) fakePlayer = Instantiate(fakePlayerObj).GetComponent<FakePlayer>();
        }
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint")?.transform;
            if (spawnPoint == null)
            {
                spawnPoint = new GameObject("SpawnPoint").transform;
                spawnPoint.position = playerObj.transform.position;
                spawnPoint.tag = "SpawnPoint";
            } 
        }
        else playerObj.transform.position = spawnPoint.position;
    }
    public void Death()
    {
        playerObj.SetActive(false);
        fakePlayer.Disappear(playerObj.transform);
        Invoke(nameof(Appear), 2f);
    }
    public void GameOver(bool isWin)
    {
        //AudioManager.Instance.StopMusic();
        if (isWin)
        {
            AudioManager.Instance.PlaySFX("WinGame");
            if (SceneInteractable.GetIndexScene() == levelUnlock)
            {
                levelUnlock++;
                PlayerPrefs.SetInt("LevelUnlock", levelUnlock);
            }
        } 
        else AudioManager.Instance.PlaySFX("GameOver");
        FruitCoinManager.Instance.UpdateFruitCoin();
        playerObj.SetActive(isWin);
        Debug.Log("Fix Input");
        //InputManager.Instance.DisableInput();
        PauseMenu.Instance.GameOver(isWin);
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
}