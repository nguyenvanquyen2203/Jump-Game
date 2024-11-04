using System.Collections.Generic;
using UnityEngine;

public class Plant : AttackMonster, IShootable
{
    public BulletManager plantBulletManager;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        plantBulletManager.SetDirection(Vector2.left);
        plantBulletManager.SetPiece(CollectionManager.Instance.pieceBreakCtrl);

        cooldownAttack = 0;     
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
    }
    public override void Attack()
    {
        if (cooldownAttack > 0) return;
        ChangeState("attack");
        RunAnim();
        cooldownAttack = timeAttack;
    }
    public void SpawnBullet() => plantBulletManager.ActiveBullet(bulletSpawnPoint.position);
}
