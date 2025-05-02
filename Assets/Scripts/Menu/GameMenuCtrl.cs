using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuCtrl : MonoBehaviour, IInputObserver
{
    public Image bG;
    public GameObject pauseMenu;

    public GameObject overMenu;
    public GameObject lockPanel;
    private static GameMenuCtrl instance;
    public static GameMenuCtrl Instance { get { return instance; } }
    private InputAction pauseInput;
    private bool isPause;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        pauseInput = InputCtrl.Instance.GetInput(this).Control.Exit;
    }
    private void OnDisable()
    {
        DisableInput();
    }
    private void Start()
    {
        //pauseInput = InputCtrl.Instance.GetInput(this).Control.Exit;
        bG.color = SomeColor.black(0);
        isPause = false;
    }
    private void ExitAct(InputAction.CallbackContext obj)
    {
        if (!isPause) PauseGame();
        else ResumeGame();
    }
    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        OpenMenu(pauseMenu);
    }
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        DisappearMenu(pauseMenu);
    }
    public void GameOver(bool _isWin)
    {
        OpenMenu(overMenu);
        lockPanel.SetActive(!_isWin);
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
        AppearMenu(menu);
    }
    private void AppearMenu(GameObject menu)
    {
        LeanTween.value(gameObject, (value) => { bG.color = value; }, SomeColor.black(0), SomeColor.black(.5f), .8f).setEase(LeanTweenType.easeOutQuad).setIgnoreTimeScale(true);
        menu.LeanScale(Vector2.one, .8f).setIgnoreTimeScale(true);
    }
    public void DisappearMenu(GameObject menu)
    {
        LeanTween.value(gameObject, (value) => { bG.color = value; }, SomeColor.black(.5f), SomeColor.black(0), .5f).setEase(LeanTweenType.easeOutQuad);
        menu.LeanScale(Vector2.zero, .5f).setOnComplete(() => { menu.SetActive(false); }).setIgnoreTimeScale(true).setEaseInBack();
    }

    public void DisableInput()
    {
        pauseInput.performed -= ExitAct;
    }

    public void EnableInput()
    {
        pauseInput.performed += ExitAct;
    }
    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void NextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void BackHome() => SceneManager.LoadScene(0);
}
