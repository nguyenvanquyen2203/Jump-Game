public class Heart : Item
{
    protected override void CollectorAction()
    {
        PlayerHealth.Instance.GetHeart();
    }

}
