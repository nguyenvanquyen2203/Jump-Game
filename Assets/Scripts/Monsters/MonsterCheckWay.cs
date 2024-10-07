using UnityEngine;

public class MonsterCheckWay : MonoBehaviour
{
    [SerializeField] private bool isIn;
    private Monster monster;
    private void Awake()
    {
        monster = transform.parent.GetComponent<Monster>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isIn && !monster.IsDead()) monster.ChangeDirection();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isIn && !monster.IsDead()) monster.ChangeDirection();
    }
}