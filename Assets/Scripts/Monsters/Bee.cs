using UnityEngine;

public class Bee : FlyingMonster, IShootable, IAttackable
{
    public BulletManager beeBulletManager;
    private Vector3 centerPos;
    private bool lockMove;
    private Vector3 moveVector;
    public float timeAttack;
    public Transform bulletSpawnPoint;
    private float cooldownAttack;

    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        centerPos = transform.position;
        ChangeDirection();
        cooldownAttack = timeAttack;
        beeBulletManager.SetDirection(Vector2.down);
        beeBulletManager.SetPiece(CollectionManager.Instance.beePieceBreakCtrl);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldownAttack > 0f) cooldownAttack -= Time.fixedDeltaTime;
        if (cooldownAttack <= 0f) Attack();
    }
    protected void ChangeDirection()
    {
        float moveTime = 0;
        moveVector = new Vector3(Random.Range(-moveSpace.x, moveSpace.x), Random.Range(-moveSpace.y, moveSpace.y * 1 / 2), 0f);
        Vector2 targetPos = centerPos + new Vector3(moveVector.x, Mathf.Clamp(moveVector.y, -moveSpace.y, 0f), moveVector.z);
        base.ChangeDirection(-transform.position + new Vector3(targetPos.x, targetPos.y, transform.position.z));
        moveTime = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).magnitude / speed;
        Invoke(nameof(ChangeDirection), moveTime);
    }
    public void SpawnBullet()
    {
        beeBulletManager.ActiveBullet(bulletSpawnPoint.position);
    }

    public void Attack()
    {
        cooldownAttack = timeAttack;
        ChangeState("attack");
        LockState();
        RunAnim();
    }
}
