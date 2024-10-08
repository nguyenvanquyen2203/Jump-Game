using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Animator itemAnim;
    private void Awake()
    {
        itemAnim = GetComponent<Animator>();
    }
    protected abstract void CollectorAction();
    public void Collect()
    {
        AudioManager.Instance.PlaySFX("Collection");
        CollectorAction();
        Disable();
    }
    public void RunAnim(string _state)
    {
        itemAnim.Play(_state);
    }
    private void Disable()
    {
        CollectionManager.Instance.ActiveFruitCollection(transform.position);
        gameObject.SetActive(false);
    }
}
