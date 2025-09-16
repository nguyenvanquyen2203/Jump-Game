using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance { get { return instance; } }
    // Rotate Item
    private List<Item> itemsRotate;
    public float rotateSpeed;
    private float currentAngle = 0;

    // Undulate Item
    private List<ItemUndulate> itemsUndulate;
    public float amplitude;
    public float angularFrequency;
    private float undulateTime;
    Vector3 orginalPos;

    private void Awake()
    {
        itemsRotate = new List<Item>();
        itemsUndulate = new List<ItemUndulate>();
        instance = this;
    }
    public void AddRotateItem(Item item) => itemsRotate.Add(item);
    public void RemoveRotateItem(Item item) => itemsRotate.Remove(item);
    private void FixedUpdate()
    {
        undulateTime += Time.fixedDeltaTime;
        float x = amplitude * Mathf.Cos(undulateTime * angularFrequency * Mathf.PI / 180);
        foreach (var item in itemsRotate) item.transform.rotation = Quaternion.Euler(((int)(undulateTime * rotateSpeed) % 360) * Vector3.up);
        foreach (var item in itemsUndulate) item.SetYPos(x);
    }
    public void AddUndulateItem(ItemUndulate item) => itemsUndulate.Add(item);
    public void RemoveUndulateItem(ItemUndulate item) => itemsUndulate.Remove(item);
}