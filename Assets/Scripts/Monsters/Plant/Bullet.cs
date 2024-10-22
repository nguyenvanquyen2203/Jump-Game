using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private CollectionManager collectionManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collectionManager = CollectionManager.Instance;
        direction = Vector2.right;
        bulletSpeed = 5f;
    }
    private void OnEnable()
    {
        rb.velocity = direction * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<PlayerHealth>().Hurt();
        collectionManager.ActivePoolCtrl(collectionManager.pieceBreakCtrl, transform.position);
        gameObject.SetActive(false);
    }
    public void SetDirection(Vector2 _dir) => direction = _dir;
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
