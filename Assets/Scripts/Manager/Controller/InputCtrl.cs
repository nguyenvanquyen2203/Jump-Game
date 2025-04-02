using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    private static InputCtrl instance;
    public static InputCtrl Instance { get { return instance; } }
    private InputManager playerInput;
    private void Awake()
    {
        instance = this;
        playerInput = new InputManager();
        playerInput.Enable();
    }
    public InputManager GetInput()
    {
        if (playerInput == null)
        {
            playerInput = new InputManager();
        }
        return playerInput;
    }
}
