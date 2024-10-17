using UnityEngine;

public class FatBird : Monster
{
    public float speed;
    private bool isFall;
    private float gravity = -9.8f;
    private float velocity;
    private bool lockMove;
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
        lockMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lockMove)
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
    protected override void LockMove()
    {
        lockMove = true;
    }
    public override void UnlockMove()
    {
        lockMove = false;
    }
}