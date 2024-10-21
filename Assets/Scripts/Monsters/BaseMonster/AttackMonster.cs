public abstract class AttackMonster : Monster, IAttackable
{
    public float timeAttack;
    protected float cooldownAttack;
    public override void ResetInfo()
    {
        cooldownAttack = timeAttack;
        hp = monsterInfo.hp;
        base.ResetInfo();
    }
    public abstract void Attack();
}
