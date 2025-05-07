using System.Collections.Generic;
using UnityEngine;

public class PieceBreak : MonoBehaviour
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
