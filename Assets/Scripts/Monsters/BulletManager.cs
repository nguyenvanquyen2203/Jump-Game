using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet bulletPref;
    public int numberBullet;
    private List<Bullet> bullets = new List<Bullet>();
    private Vector2 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < numberBullet; i++)
        {
            //Bullet bullet = CreateBullet();
            bullets.Add(CreateBullet());
        }
    }
    void Start()
    {
        /*for (int i = 0; i < numberBullet; i++)
        {
            Bullet bullet = CreateBullet();
            bullets.Add(bullet);
        }*/
    }
    public void SetDirection(Vector2 dir)
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.SetDirection(dir);
        }
        direction = dir;
    }
    public void ActiveBullet(Vector3 activePos)
    {
        foreach (Bullet bullet in bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = activePos;
                return;
            } 
        }
        Bullet newBullet = CreateBullet();
        newBullet.gameObject.SetActive(true);
        bullets.Add(newBullet);
    }
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPref, transform);
        bullet.gameObject.SetActive(false);
        bullet.SetDirection(direction);
        return bullet;
    }
}
