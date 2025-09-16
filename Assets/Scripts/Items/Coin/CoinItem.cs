public class CoinItem : Item
{
    private void Start()
    {
        ItemManager.Instance.AddRotateItem(this);
    }
    protected override void CollectorAction()
    {
        GameManager.Instance.CollectCoin();
    }
    protected override void Disable()
    {
        ItemManager.Instance.RemoveRotateItem(this);
        base.Disable();
    }
}
