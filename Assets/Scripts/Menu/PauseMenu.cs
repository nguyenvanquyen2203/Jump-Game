using UnityEngine;

public class PauseMenu : SceneInteractable
{
    private static PauseMenu instance;
    public static PauseMenu Instance { get { return instance; } }
    private bool isPause;
    private bool isOver;
    public GameObject pauseMenu;
    public GameObject resumeBtn;
    public GameObject nextLvBtn;
    public GameObject lockPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        isOver = false;
        isPause = false;
        CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOver)
        {
            if (!isPause) PauseGame();
            else ResumeGame();
        }
    }
    public void GameOver(bool _isWin)
    {
        isOver = true;
        OpenMenu();
        if (_isWin)
        {
            nextLvBtn.SetActive(true);
        }
        else
        {
            nextLvBtn.SetActive(true);
            lockPanel.SetActive(true);
        }
    }
    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        OpenMenu();
        resumeBtn.SetActive(true);
    }
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        CloseMenu();
    }
    public void OpenMenu() => pauseMenu.SetActive(true);
    public void CloseMenu()
    {
        nextLvBtn.SetActive(false);
        lockPanel.SetActive(false);
        resumeBtn.SetActive(false);
        pauseMenu.SetActive(false);
    } 
}
