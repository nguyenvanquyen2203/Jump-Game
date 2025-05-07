public class AngryPig : RunMonster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    private void Start()
    {
        Move();
    }
    public override void TakeHit()
    {
        base.TakeHit();
        speed *= 1.5f;
    }
}