using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected Animator monsterAnimator;
    public MonsterInfo monsterInfo;
    protected Rigidbody2D rb;
    private string state;
    private bool lockState;
    protected int lockMove;
    protected int hp;
    private bool isDead;
    protected void InitMonster()
    {
        monsterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ResetInfo();
    }
    public virtual void ResetInfo()
    {
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

        rb.AddForce(Vector2.up * 10f + Vector2.right * (rb.velocity.x * .75f), ForceMode2D.Impulse);
        rb.gravityScale = 5f;
        Invoke(nameof(Disable), 3f);
    }
    protected void LockState() => lockState = true;
    public void UnlockState() => lockState = false;
    protected void Move(Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }
    protected virtual void LockMove()
    {
        lockMove = 0;
        //rb.velocity = Vector2.zero;
    } 
    public virtual void UnlockMove() => lockMove = 1;
    protected void Disable()
    {
        gameObject.SetActive(false);
    }
    public bool IsDead() => isDead;
}
