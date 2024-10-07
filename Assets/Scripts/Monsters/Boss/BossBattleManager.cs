using UnityEngine;

public class BossBattleManager : MonoBehaviour
{
    public Boss boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.enabled = true;        
    }
}
