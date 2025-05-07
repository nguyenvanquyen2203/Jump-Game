using UnityEngine;

public interface IMovePlatform
{
    Vector2 direction { get; set; }
    float speed { get; set; }
    public void ChangeDirection();
}
