using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneInteractable
{
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static int GetIndexScene() => SceneManager.GetActiveScene().buildIndex;
}
