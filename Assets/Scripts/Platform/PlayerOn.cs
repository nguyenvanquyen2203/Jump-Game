using UnityEngine;

public class PlayerOn : MonoBehaviour, IPlatformObs
{
    private PlatformSubject subject;
    private IMovePlatform movePlatform;
    private PlayerMovement player;
    //private float speed;
    private Vector2 velocity = Vector2.zero;
    private void Awake()
    {
        subject = GetComponent<PlatformSubject>();
        movePlatform = GetComponent<IMovePlatform>();
    }
    private void Start()
    {
        //velocity = movePlatform.direction;
        //speed = movePlatform.speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerMovement>();
        SetBonus(velocity);
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
        //direction = movePlatform.direction;
        SetBonus(velocity);
    } 
    public void OnNotify()
    {
        ChangeDirection();
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void SetVelocity(Vector2 velocity)
    {
        if (velocity.x == 0) velocity.y /= 2;
        SetBonus(velocity);
        this.velocity = velocity;
    }
}
