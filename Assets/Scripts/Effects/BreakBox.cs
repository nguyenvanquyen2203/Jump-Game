using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    private static BreakBox instance;
    public static BreakBox Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    public List<ParticleSystem> pieces;
    public void Break(Vector3 position)
    {
        transform.position = position;  
        foreach (ParticleSystem piece in pieces)
        {
            piece.gameObject.SetActive(true);
            piece.Play();
        }
    }
}
