using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    public void Destroy()
    {
        Invoke(nameof(Enable), 3f);
        gameObject.SetActive(false);
    }
    private void Enable()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        GroundDestroyEffect.Instance.Active(transform.position);
        Destroy();
    }
}
