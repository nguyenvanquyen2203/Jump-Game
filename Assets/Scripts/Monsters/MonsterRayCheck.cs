using UnityEngine;

public class MonsterRayCheck : MonoBehaviour
{
    private BoxCollider2D box;
    private AttackMonster monster;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask checkLayer;
    private void Awake()    
    {
        box = GetComponent<BoxCollider2D>();
        monster = GetComponent<AttackMonster>();
    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(box.bounds.center, transform.right * transform.localScale.x * -1f, rayDistance, checkLayer))
        {
            monster.CanAttack(true);
        }
        else { monster.CanAttack(false); }
    }
}