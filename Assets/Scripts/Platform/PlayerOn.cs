using UnityEngine;

public class PlayerOn : Subject, IObserver
{
    private PointToPoint pointToPoint;
    private PlayerMovement player;
    private float speed;
    private int direction;
    private void Awake()
    {
        pointToPoint = GetComponent<PointToPoint>();
    }
    private void Start()
    {
        direction = pointToPoint.direction;
        speed = pointToPoint.speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerMovement>();
        SetBonus(Vector2.right * speed * direction);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        SetBonus(Vector2.zero);
        player = null;
    }
    public void SetBonus(Vector2 bonusVector) => player?.SetBonus(bonusVector);
    private void OnEnable()
    {
        pointToPoint.AddObserver(this);
    }
    private void ChangeDirection()
    {
        direction = pointToPoint.direction;
        SetBonus(Vector2.right * speed * direction);
    } 
    public void OnNotify()
    {
        ChangeDirection();
    }
    private void OnDisable()
    {
        pointToPoint.RemoveObserver(this);
    }
}
