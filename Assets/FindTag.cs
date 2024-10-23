using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectsInLayer = GameObject.FindGameObjectsWithTag("Monster");

        foreach (GameObject obj in objectsInLayer)
        {
            Debug.Log("Object found: " + obj.name);
        }
    }
}
