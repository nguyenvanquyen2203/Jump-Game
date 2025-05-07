using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBreakRB : MonoBehaviour
{
    public List<Rigidbody2D> pieces;
    public float lifeTime;
    public Vector2 force;
    private void OnEnable()
    {
        foreach (Rigidbody2D piece in pieces)
        {
            piece.transform.position = transform.position;
            Vector2 randomForce = new Vector2(Random.Range(-force.x, force.x), Random.Range(0, force.y));
            piece.AddForce(randomForce);
        }
        Invoke(nameof(UnactivePieces), lifeTime);
    }
    private void UnactivePieces() => gameObject.SetActive(false);
}
