using UnityEngine;

public class Goal : MonoBehaviour
{
    private Animator anim;
    private bool isActive;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        isActive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!isActive)
        {
            isActive = true;
            anim.enabled = true;
            anim.Play("end");
            WinGame();
        }
    }
    public void WinGame() => GameManager.Instance.GameOver(true);
}
