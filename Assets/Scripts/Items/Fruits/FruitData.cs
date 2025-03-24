using UnityEngine;

public class FruitData : MonoBehaviour
{
    private static FruitData instance;
    public static FruitData Instance { get { return instance; } }
    public FruitsDatabase fruitsDB;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public Fruit GetFruit(string nameFruit) => fruitsDB.GetFruit(nameFruit);
}
