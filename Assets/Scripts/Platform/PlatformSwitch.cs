using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    private PointToPoint platformMove;
    // Start is called before the first frame update
    private void Awake()
    {
        platformMove = GetComponent<PointToPoint>();
    }
    void Start()
    {
        platformMove.TurnOff();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformMove.TurnOn();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        platformMove.TurnOff();
    }
}
