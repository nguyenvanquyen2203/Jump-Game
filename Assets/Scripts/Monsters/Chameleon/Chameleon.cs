using UnityEngine;

public class Chameleon : Monster
{
    [SerializeField] private float timeAttack;
    private float cooldownAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        canAttack = false;
        cooldownAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lockMove != 0) Move();
        if (cooldownAttack <= 0 && canAttack)
        {
            rb.velocity = Vector2.zero;
            LockMove();
            ChangeState("attack");
            RunAnim();
            cooldownAttack = timeAttack;
        }
        if (cooldownAttack > 0) cooldownAttack -= Time.deltaTime;
    }
}
