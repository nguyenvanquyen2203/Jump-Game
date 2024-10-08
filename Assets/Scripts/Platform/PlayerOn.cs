using UnityEngine;

public class PlayerOn : MonoBehaviour, IObserver
{
    private Subject subject;
    private IMovePlatform movePlatform;
    private PlayerMovement player;
    private float speed;
    private Vector2 direction;
    private void Awake()
    {
        subject = GetComponent<Subject>();
        movePlatform = GetComponent<IMovePlatform>();
    }
    private void Start()
    {
        direction = movePlatform.direction;
        speed = movePlatform.speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerMovement>();
        SetBonus(speed * direction);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        SetBonus(Vector2.zero);
        player = null;
    }
    public void SetBonus(Vector2 bonusVector) => player?.SetBonus(bonusVector);
    private void OnEnable()
    {
        subject.AddObserver(this);
    }
    private void ChangeDirection()
    {
        direction = movePlatform.direction;
        SetBonus(speed * direction);
    } 
    public void OnNotify()
    {
        ChangeDirection();
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }
}
