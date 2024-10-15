using System.Collections.Generic;
using UnityEngine;

public class Plant : RunMonster, IAttackable
{
    public GameObject bulletPref;
    public Transform bulletSpawnPoint;
    public int numberBullets;
    private List<Bullet> bullets = new List<Bullet>();
    [SerializeField] private float timeAttack;
    private float cooldownAttack;

    public bool canAttack { get ; set ; }

    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        #region Create list bullet
        for (int i = 0; i < numberBullets; i++)
        {
            Bullet newBullet = CreateBullet();
            newBullet.gameObject.SetActive(false);
            bullets.Add(newBullet);
        }
        #endregion

        canAttack = false;
        cooldownAttack = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownAttack <= 0 && canAttack)
        {
            ChangeState("attack");
            RunAnim();
            cooldownAttack = timeAttack;
        }
        if (cooldownAttack > 0) cooldownAttack -= Time.deltaTime;
    }
    public void Attack()
    {
        foreach (Bullet bullet in bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.transform.position = bulletSpawnPoint.position;
                bullet.gameObject.SetActive(true);
                return;
            }
        }
        Bullet newBullet = CreateBullet();
        newBullet.transform.position = bulletSpawnPoint.position;
        bullets.Add(newBullet);
    }
    public Bullet CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPref, transform);
        bullet.GetComponent<Bullet>().SetDirection((int)transform.localScale.x * -1);
        return bullet.GetComponent<Bullet>();
    }
}
