using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected Animator monsterAnimator;
    protected Rigidbody2D rb;
    private string state;
    private bool lockState;
    private int direction;
    protected int lockMove;
    public MonsterInfo monsterInfo;
    protected int hp;
    protected float speed;
    private bool isDead;
    protected void InitMonster()
    {
        monsterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ResetInfo();
    }
    public void ResetInfo()
    {
        hp = monsterInfo.hp;
        speed = monsterInfo.speed;
        direction = 1;
        UnlockState();
        UnlockMove();
        isDead = false;

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Kinematic;

        #region Rotate GO
        GetComponent<DeathRotate>().enabled = false;
        #endregion
    }
    public void ChangeState(string _state)
    {
        if (!lockState) state = _state;
    }
    public void RunAnim()
    {
        monsterAnimator.Play(state);
    }
    public virtual void TakeHit()
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
    public void TakeHitAction()
    {
        if (hp > 0)
        {
            UnlockMove();
            UnlockState();
        } 
    }
    protected void Death()
    {
        LockState();
        isDead = true;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;

        #region Rotate GO
        GetComponent<DeathRotate>().enabled = true;
        #endregion

        rb.AddForce(Vector2.up * 10f + Vector2.right * (speed * .75f) * direction, ForceMode2D.Impulse);
        rb.gravityScale = 5f;
        Invoke(nameof(Disable), 3f);
    }
    protected void LockState() => lockState = true;
    public void UnlockState() => lockState = false;
    protected void Move()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }
    protected void LockMove()
    {
        lockMove = 0;
        rb.velocity = Vector2.zero;
    } 
    public void UnlockMove() => lockMove = 1;
    protected void Disable()
    {
        gameObject.SetActive(false);
    }
    public virtual void ChangeDirection()
    {
        transform.localScale = new Vector3(direction, 1, 1);
        direction *= -1;
    }
    public bool IsDead() => isDead;
}
