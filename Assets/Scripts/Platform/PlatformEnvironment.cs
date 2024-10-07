using UnityEngine;

public class PlatformEnvironment : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= .01f) gameObject.layer = LayerMask.NameToLayer("Platform");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
