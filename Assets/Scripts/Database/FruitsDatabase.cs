using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FruitDB")]
public class FruitsDatabase : ScriptableObject
{
    public Fruit[] fruits;
    public Fruit GetFruit(string nameFruit)
    {
        Fruit fruit = Array.Find(fruits, fruit => fruit.fruitName == nameFruit);
        if (fruit == null) Debug.LogError($"Can't find {nameFruit} fruit");
        return fruit;
    }
}
