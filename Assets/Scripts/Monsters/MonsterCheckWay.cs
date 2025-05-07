using UnityEngine;

public class MonsterCheckWay : MonoBehaviour
{
    [SerializeField] private bool isIn;
    private RunMonster monster;
    private void Awake()
    {
        monster = transform.parent.GetComponent<RunMonster>();
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