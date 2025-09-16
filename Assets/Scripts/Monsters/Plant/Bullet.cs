using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private CollectionManager collectionManager;
    private CollectionManager.PoolType bulletType;
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
        if (collision.CompareTag("Monster")) return;
        if (collision.CompareTag("Player")) collision.GetComponent<PlayerHealth>().Hurt();
        collectionManager.ActivePoolCtrl(bulletType, transform.position);
        gameObject.SetActive(false);
    }
    public void SetDirection(Vector2 _dir) => direction = _dir;
    public void SetPieceBreakCtrl(BulletManager.BulletType type)
    {
        if (type == BulletManager.BulletType.BeeBullet) bulletType = CollectionManager.PoolType.BeePiece;
        if (type == BulletManager.BulletType.PlantBullet) bulletType = CollectionManager.PoolType.PlantPiece;
    }
}
