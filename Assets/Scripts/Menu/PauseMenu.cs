using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance;
    public static PauseMenu Instance { get { return instance; } }
    private InputAction pauseInput;
    private bool isPause;
    private bool isOver;
    public Image bG;
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
        pauseInput = InputCtrl.Instance.GetInput().Control.Exit;
        pauseInput.performed += ExitAct;
        Time.timeScale = 1.0f;
        isOver = false;
        isPause = false;
        DisappearMenu();
        pauseMenu.transform.localScale = Vector2.zero;
    }

    private void ExitAct(InputAction.CallbackContext obj)
    {
        if (!isPause) PauseGame();
        else ResumeGame();
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
        DisappearMenu();
    }
    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        AppearMenu();
    }
    public void DisappearMenu()
    {
        LeanTween.value(gameObject, (value) => { bG.color = value; }, SomeColor.black(.5f), SomeColor.black(0), .5f).setEase(LeanTweenType.easeOutQuad);
        pauseMenu.LeanScale(Vector2.zero, .5f).setOnComplete(CloseMenu).setIgnoreTimeScale(true).setEaseInBack();
    }

    #region Animations
    private void AppearMenu()
    {
        LeanTween.value(gameObject, (value) => { bG.color = value; }, SomeColor.black(0), SomeColor.black(.5f), .8f).setEase(LeanTweenType.easeOutQuad).setIgnoreTimeScale(true);
        pauseMenu.LeanScale(Vector2.one, .8f).setIgnoreTimeScale(true);
    }
    public void CloseMenu()
    {
        nextLvBtn.SetActive(false);
        lockPanel.SetActive(false);
        resumeBtn.SetActive(false);
        pauseMenu.SetActive(false);
    }
    #endregion
    public void LoadScene(int index)
    {
        SceneInteractable.LoadScene(index);
    }
    public void ReloadScene()
    {
        SceneInteractable.Reload();
    }
    public void LoadNextScene()
    {
        SceneInteractable.LoadNextScene();
    }
}
