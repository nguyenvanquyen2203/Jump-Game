using UnityEngine;

public class FruitItem : Item
{
    public string nameFruit;
    private int score;
    private Animator fruitAnim;
    private Fruit fruitItem;

    protected override void CollectorAction()
    {
        FruitCoinManager.Instance.CollectCoin(nameFruit);
    }
    void Start()
    {
        fruitAnim = GetComponent<Animator>();
        fruitItem = FruitsManager.Instance.GetFruit(nameFruit);
        fruitAnim.runtimeAnimatorController = fruitItem.animator;
    }
}
