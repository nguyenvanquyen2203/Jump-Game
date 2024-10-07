using UnityEngine;

public class DustPSEnvironment : MonoBehaviour
{
    public int indexEnvironment;
    private DustPSCtrl dustCtrl;
    private void Awake()
    {
        dustCtrl = transform.parent.GetComponent<DustPSCtrl>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) dustCtrl.SetDust(indexEnvironment);
    }
}
