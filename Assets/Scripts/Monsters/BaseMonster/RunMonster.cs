using UnityEngine;

public abstract class RunMonster : Monster
{
    protected float speed;
    protected int direction;
    public virtual void ChangeDirection()
    {
        transform.localScale = new Vector3(direction, 1, 1);
        direction *= -1;
        Move();
    }
    public override void ResetInfo()
    {
        hp = monsterInfo.hp;
        speed = monsterInfo.speed;
        base.ResetInfo();
        direction = 1;
    }
    protected void Move()
    {
        base.Move(speed * Vector2.right * direction);
    }
    protected override void LockMove()
    {
        base.Move(Vector2.zero);
    }
    public override void UnlockMove()
    {
        Move();
    }
}
