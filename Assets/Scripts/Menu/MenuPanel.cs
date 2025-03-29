using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public Button closeBtn;
    public void DisableAction()
    {
        closeBtn.interactable = false;
    }
    public void EnableAction()
    {
        closeBtn.interactable = true;
    }
}
