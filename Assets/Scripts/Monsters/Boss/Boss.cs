using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    protected Animator monsterAnimator;
    private SpriteRenderer spriteRenderer;
    private string state;
    private bool lockState;
    protected int lockMove;
    protected bool canAttack;
    [SerializeField] protected int hp;
    [SerializeField] protected float speed;
    protected int direction;
    public void InitMonster()
    {
        monsterAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lockState = false;
        lockMove = 1;
    }
    public void ChangeState(string _state)
    {
        if (!lockState) this.state = _state;
    }
    public void RunAnim()
    {
        monsterAnimator.Play(state);
    }
    public abstract void TakeHit();
    public void Death()
    {
        gameObject.SetActive(false);
        //DeathEffectManager.Instance.Active(transform.position);
    }
    public void LockState() => lockState = true;
    public void UnlockState() => lockState = false;
    public bool MoveToPoint(Transform targetPoint)
    {
        if ((transform.position - targetPoint.position).sqrMagnitude < .01f) return true;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime * lockMove);
        return false;
    }
    protected void Flip()
    {
        direction *= -1;
        spriteRenderer.flipX = direction != -1;
    }
    protected abstract void OnCollisionEnter2D(Collision2D collision);
    public void LockMove() => lockMove = 0;
    public void UnlockMove() => lockMove = 1;
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void CanAttack(bool _canAttack) => canAttack = _canAttack;
}
