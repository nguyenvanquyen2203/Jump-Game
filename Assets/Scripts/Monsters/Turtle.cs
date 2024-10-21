using UnityEngine;

public class Turtle : AttackMonster
{
    private int state;
    public override void Attack()
    {
        SpikeOut();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
        state = 0;
    }
    private void FixedUpdate()
    {
        if (cooldownAttack <= 0)
        {
            if (state == 0)
            {
                SpikeOut();
                state = 1;
            } 
            else
            {
                SpikeIn();
                state = 0;
            }
            RunAnim();
        }
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
    }

    private void SpikeIn()
    {
        ChangeState("spikeIn");
        gameObject.tag = "Monster";
        gameObject.layer = LayerMask.NameToLayer("Monster");
        cooldownAttack = timeAttack;
    }

    protected void SpikeOut()
    {
        ChangeState("spikeOut");
        gameObject.tag = "Trap";
        gameObject.layer = LayerMask.NameToLayer("Trap");
        cooldownAttack = timeAttack * 2/3f;
    }
    public override void TakeHit()
    {
        base.TakeHit();
        cooldownAttack = .5f;
    }
}
