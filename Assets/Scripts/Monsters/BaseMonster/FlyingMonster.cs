using System.Linq.Expressions;
using UnityEngine;

public abstract class FlyingMonster : Monster
{
    protected Vector2 direction;
    protected float speed;
    [SerializeField] protected Vector2 moveSpace;
    public override void ResetInfo()
    {
        hp = monsterInfo.hp;
        speed = monsterInfo.speed;
        base.ResetInfo();
    }
    protected void Move()
    {
        base.Move(direction * speed);
    }
    protected virtual void ChangeDirection(Vector2 newDirection)
    {
        transform.localScale = new Vector3(newDirection.x > 0 ? 1 : -1, 1, 1);
        direction = newDirection.normalized;
        Move();
    }
}
