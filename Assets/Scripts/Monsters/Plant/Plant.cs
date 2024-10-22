using System.Collections.Generic;
using UnityEngine;

public class Plant : AttackMonster, IShootable
{
    [field: SerializeField] public GameObject bulletPref { get; set; }
    public Transform bulletSpawnPoint;
    public int numberBullets;
    private List<Bullet> bullets = new List<Bullet>();

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
    public void SpawnBullet()
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
        bullet.GetComponent<Bullet>().SetDirection(transform.localScale.x * Vector2.left);
        return bullet.GetComponent<Bullet>();
    }
}
