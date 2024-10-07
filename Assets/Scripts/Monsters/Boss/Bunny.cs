using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bunny : Boss
{
    private Rigidbody2D rb;
    [SerializeField] private float delayJump;
    [SerializeField] private float jumpForce;
    private float cooldownJump;
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        cooldownJump = 0;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack && cooldownJump <= 0)
        {
            JumpAction();
        }
        else if (rb.velocity.y * rb.velocity.y <= 0.01f)
        {
            ChangeState("run");
            RunActon();
        }
        else if (rb.velocity.y > 0) ChangeState("jump");
            else ChangeState("fall");
        if (cooldownJump > 0) cooldownJump -= Time.deltaTime;
        RunAnim();
    }
    private void JumpAction()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        cooldownJump = delayJump;
    }
    private void RunActon()
    {
        rb.velocity = Vector2.right * speed * direction * lockMove;
    }
    public override void TakeHit()
    {
        hp--;
        if (hp > 0)
        {
            LockMove();
            ChangeState("takeHit");
            LockState();
            RunAnim();
        }
        else Death();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("HitBox"))
        {
            collision.transform.parent.GetComponent<PlayerMovement>().Attack();
            TakeHit();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Hurt();
        }*/
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Hurt();
        }

        if (collision.gameObject.CompareTag("TargetPoint")) Flip();
        else if (collision.gameObject.CompareTag("GroundPlatform"))
        {
            TakeHit();
            if (rb.velocity.y > 0.02f)
            {
                TakeHit();
                //rb.velocity = new Vector2 (rb.velocity.x, 0);
            }
        }
    }
}
