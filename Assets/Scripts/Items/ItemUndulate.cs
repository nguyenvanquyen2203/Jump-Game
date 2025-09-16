using UnityEngine;
public abstract class ItemUndulate : Item
{
    private Vector3 originalPos;
    protected virtual void Start()
    {
        ItemManager.Instance.AddUndulateItem(this);
        originalPos = transform.position;
    }
    protected override void Disable()
    {
        ItemManager.Instance.RemoveUndulateItem(this);
        base.Disable();
    }
    public void SetYPos(float yPos) => transform.position = originalPos + yPos * Vector3.up;
    
}
