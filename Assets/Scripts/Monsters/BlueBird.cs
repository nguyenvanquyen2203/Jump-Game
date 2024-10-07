using UnityEngine;

public class BlueBird : Monster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        BirdMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockMove != 0)
        {
            Move();
        }
    }
    /*public override void TakeHit()
    {
        hp--;
        if (hp > 0)
        {
            LockMove();
            ChangeState("takeHit");
            RunAnim();
        }
        else Death();
    }*/
    public void BirdMove()
    {
        ChangeDirection();
        Invoke(nameof(BirdMove), 3f);
    }
}
