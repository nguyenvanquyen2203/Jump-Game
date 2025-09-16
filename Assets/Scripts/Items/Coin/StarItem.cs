public class StarItem : ItemUndulate
{
    protected override void Start()
    {
        base.Start();
        ItemManager.Instance.AddRotateItem(this);
    }
    protected override void CollectorAction()
    {
        GameManager.Instance.CollectStar();
    }
    protected override void Disable()
    {
        ItemManager.Instance.RemoveRotateItem(this);
        base.Disable();
    }
}
