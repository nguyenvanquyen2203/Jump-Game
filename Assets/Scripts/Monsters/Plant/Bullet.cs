using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1;
        bulletSpeed = 5f;
    }
    private void OnEnable()
    {
        Invoke(nameof(OnDisable), 5f);
        rb.velocity = new Vector2 (bulletSpeed * direction, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<PlayerHealth>().Hurt();
        else gameObject.SetActive(false);
    }
    public void SetDirection(int _dir) => direction = _dir;
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
