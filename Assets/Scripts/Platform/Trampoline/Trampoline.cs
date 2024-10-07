using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float trampolineForce;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y > -.5f) return;        
            anim.enabled = true;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(trampolineForce * Vector2.up, ForceMode2D.Impulse);
        } 
    }
    public void Disable()
    {
        anim.enabled = false;
    }
}
