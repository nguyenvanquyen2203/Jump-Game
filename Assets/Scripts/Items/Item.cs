using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected CollectionManager collectionManager;
    protected void Awake()
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
    protected virtual void Disable()
    {
        collectionManager.ActivePoolCtrl(collectionManager.fruitCollect, transform.position);
        gameObject.SetActive(false);
    }
}
