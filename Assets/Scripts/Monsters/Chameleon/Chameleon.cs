using UnityEngine;

public class Chameleon : RunMonster, IAttackable
{
    [SerializeField] private float timeAttack;
    private float cooldownAttack;

    public bool canAttack { get ; set ; }

    public void ShotBullet()
    {
        if (cooldownAttack <= 0)
        {
            rb.velocity = Vector2.zero;
            LockMove();
            ChangeState("attack");
            RunAnim();
            cooldownAttack = timeAttack;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        canAttack = false;
        cooldownAttack = 0;
        Move();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
    }
}
