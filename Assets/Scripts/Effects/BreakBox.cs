using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    public List<ParticleSystem> pieces;
    private void OnEnable()
    {
        foreach (ParticleSystem piece in pieces)
        {
            piece.gameObject.SetActive(true);
            piece.Play();
        }
    }
}
