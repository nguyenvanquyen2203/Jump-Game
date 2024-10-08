using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    public PoolCtrl slimeParticalCtrl;
    private float cooldown;
    private void Awake()
    {
        InitMonster();
        cooldown = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lockMove != 0)
        {
            Move();
        }
        if (IsDead()) return;
        if (cooldown > 0f) cooldown -= Time.fixedDeltaTime;
        else
        {
            cooldown = 1f;
            slimeParticalCtrl.ActivePool(transform.position - Vector3.up * .825f);
        }
    }
}
