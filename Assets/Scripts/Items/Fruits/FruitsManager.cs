using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    private static FruitsManager instance;
    public static FruitsManager Instance { get { return instance; } }
    public FruitsDatabase fruitsDB;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public Fruit GetFruit(string nameFruit) => fruitsDB.GetFruit(nameFruit);
}
