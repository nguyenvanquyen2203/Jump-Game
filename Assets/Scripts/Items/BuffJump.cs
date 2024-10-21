using UnityEngine;

public class BuffJump : Item
{
    public float buffJumpForce;
    public float timeActive;
    protected override void CollectorAction()
    {
        PlayerHealth.Instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerHealth.Instance.GetComponent<Rigidbody2D>().AddForce(buffJumpForce * Vector2.up, ForceMode2D.Impulse);
    }
    protected override void Disable()
    {
        collectionManager.ActivePoolCtrl(collectionManager.buffJumpCtrl, transform.position);
        //collectionManager.ActiveFruitCollection(transform.position);
        Invoke(nameof(ActiveBuffJump), timeActive);
        gameObject.SetActive(false);
    }
    private void ActiveBuffJump()
    {
        gameObject.SetActive(true);
    }
}
