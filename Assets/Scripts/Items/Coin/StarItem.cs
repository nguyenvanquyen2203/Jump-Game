public class StarItem : Item
{
    protected override void CollectorAction()
    {
        GameManager.Instance.CollectStar();
    }
}
