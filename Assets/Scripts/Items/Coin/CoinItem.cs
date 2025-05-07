public class CoinItem : Item
{
    protected override void CollectorAction()
    {
        GameManager.Instance.CollectCoin();
    }
}
