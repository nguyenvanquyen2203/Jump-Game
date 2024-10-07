using UnityEngine;

public class Chicken : Monster
{
    // Start is called before the first frame update
    private void Awake()
    {
        base.InitMonster();
    }
    private void OnEnable()
    {
        ResetInfo();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    // Update is called once per frame
    void Update()
    {
        if (lockMove != 0)
        {
            Move();
        }
    }
    public override void TakeHit()
    {
        hp--;
        if (hp >= 0)
        {
            LockMove();
            ChangeState("takeHit");
            LockState();
            RunAnim();
        }
        if (hp <= 0) monsterAnimator.SetBool("isDead", true);
        if (hp <= 0) Death();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Wall")) return;
        if (Mathf.Abs(collision.GetContact(0).normal.x) >= .5f) TakeHit();
    }
}
