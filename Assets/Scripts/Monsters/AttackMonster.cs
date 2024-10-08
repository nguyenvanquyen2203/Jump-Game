public class AttackMonster : Monster
{
    protected bool canAttack;
    public void CanAttack(bool _canAttack) => canAttack = _canAttack;
}
