using UnityEngine;

public class FruitItem : Item
{
    public string nameFruit;
    private int score;
    private Animator fruitAnim;
    private Fruit fruitItem;

    protected override void CollectorAction()
    {
        PointManager.Instance.CollectPoint(score);
    }
    void Start()
    {
        fruitAnim = GetComponent<Animator>();
        fruitItem = FruitsManager.Instance.GetFruit(nameFruit);
        score = fruitItem.Score;
        fruitAnim.runtimeAnimatorController = fruitItem.animator;
    }
}
