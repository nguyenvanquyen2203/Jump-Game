using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject boxItem;
    public int boxHp;
    private CollectionManager collectionManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        collectionManager = CollectionManager.Instance;
    }
    public void TakeHit()
    {
        boxHp--;
        if (boxHp <= 0) collectionManager.ActivePoolCtrl(collectionManager.boxBreakCtrl, transform.position);
        anim.Play("takeHit");
    }
    public void TakeHitAct()
    {
        if (boxHp <= 0)
        {
            Destroy();
            gameObject.SetActive(false);
        } 
    }
    public void Destroy()
    {
        if (boxItem == null) return;
        GameObject item = Instantiate(boxItem, transform.position, Quaternion.identity);
        item.SetActive(true);
    } 
}