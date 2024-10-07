using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Monster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
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
}
