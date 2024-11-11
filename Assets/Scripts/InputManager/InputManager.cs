using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float horizontal;
    private bool jump;
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        jump = false; 
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) jump = true;
    }
    public float GetHorizontal() => horizontal;
    public bool GetJump() => jump;
    public void DisableInput()
    {
        horizontal = 0;
        jump = false;
        gameObject.SetActive(false);
    }
}
