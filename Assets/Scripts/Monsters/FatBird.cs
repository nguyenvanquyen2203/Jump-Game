using UnityEngine;

public class FatBird : Monster
{
    private bool isFall;
    private float gravity = -9.8f;
    private float velocity;
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    void Start()
    {
        isFall = true;
        velocity = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lockMove != 0)
        {
            if (isFall)
            {
                ChangeState("fall");
                velocity += gravity * Time.fixedDeltaTime;
            }
            else
            {
                ChangeState("idle");
                velocity = speed;
            }
            RunAnim();
            Move(velocity * Vector2.up);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        LockMove();
        ChangeState("ground");
        LockState();
        RunAnim();
        isFall = !isFall;
        velocity = 0f;
    }
    protected void Move(Vector2 moveVector)
    {
        rb.velocity = moveVector * speed;
    }
}
