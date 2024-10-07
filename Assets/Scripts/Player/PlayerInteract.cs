using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (collision.GetContact(0).normal.y < .5f) PlayerHealth.Instance.Hurt();
            else
            {
                collision.gameObject.GetComponent<Monster>().TakeHit();
                gameObject.GetComponent<PlayerMovement>().Attack();
            }
        }
        if (collision.gameObject.CompareTag("Platform/Box"))
        {
            if (collision.GetContact(0).normal.y > .5f) 
            {
                collision.gameObject.GetComponent<Box>().TakeHit();
                gameObject.GetComponent<PlayerMovement>().Attack();
            }
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerHealth.Instance.Hurt();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerHealth.Instance.Hurt();
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<Item>().Collect();
        }
    }
}
