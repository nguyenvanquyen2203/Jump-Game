using UnityEngine;

public abstract class BuffItem : MonoBehaviour
{
    protected CollectionManager collectionManager;
    private void Awake()
    {
        collectionManager = CollectionManager.Instance;
    }
    protected abstract void CollectorAction();
    public void Collect()
    {
        AudioManager.Instance.PlaySFX("Collection");
        CollectorAction();
        Disable();
    }
    private void Disable()
    {
        collectionManager.ActivePoolCtrl(collectionManager.buffJumpCtrl, transform.position);
        gameObject.SetActive(false);
    }
}
