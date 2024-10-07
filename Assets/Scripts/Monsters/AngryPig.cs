using UnityEngine;

public class AngryPig : Monster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
        //Move();
    }

    // Update is called once per frame
    void FixedUpdate()
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
            speed *= 1.5f;
        }
        if (hp <= 0) monsterAnimator.SetBool("isDead", true);
        if (hp <= 0) Death();
    }
    /*public override void ChangeDirection()
    {
        base.ChangeDirection();
        Move();
    }*/
}