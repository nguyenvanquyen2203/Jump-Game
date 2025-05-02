using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    private static InputCtrl instance;
    public static InputCtrl Instance { get { return instance; } }
    private InputManager playerInput;
    private List<IInputObserver> observers = new List<IInputObserver>();
    private void Awake()
    {
        instance = this;
        playerInput = new InputManager();
        playerInput.Enable();
    }
    public InputManager GetInput(IInputObserver obs)
    {
        if (playerInput == null)
        {
            playerInput = new InputManager();
        }
        observers.Add(obs);
        return playerInput;
    }
    public InputManager GetInput()
    {
        if (playerInput == null)
        {
            playerInput = new InputManager();
        }
        return playerInput;
    }
    public void DisableInput()
    {
        playerInput.Disable();
        foreach (var obs in observers) obs.DisableInput();
    }
    public void EnableInput()
    {
        playerInput.Enable();
        foreach (var obs in observers) obs.EnableInput();
    }
}
