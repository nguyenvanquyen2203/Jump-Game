public class AngryPig : RunMonster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    private void Start()
    {
        Move();
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
            speed *= 1.5f;
        }
        if (hp <= 0) monsterAnimator.SetBool("isDead", true);
        if (hp <= 0) Death();
    }
}