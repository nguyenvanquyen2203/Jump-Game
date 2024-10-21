using UnityEngine;

public class BlueBird : RunMonster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        BirdMove();
        Move();
    }
    public void BirdMove()
    {
        ChangeDirection();
        Invoke(nameof(BirdMove), 3f);
    }
}
