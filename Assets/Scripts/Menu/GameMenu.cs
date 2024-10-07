using UnityEngine;

public class GameMenu : SceneInteractable
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel) 
    { 
        panel.SetActive(false);
    }
}
