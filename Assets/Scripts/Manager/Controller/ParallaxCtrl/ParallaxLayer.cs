using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public GameObject background;
    public Sprite bg;
    private GameObject leftBG;
    private GameObject centerBG;
    private GameObject rightBG;
    private float backgroundWidth;
    void Awake() {
        float width = bg.bounds.size.y;
        backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        leftBG = Instantiate(background, transform);
        leftBG.transform.position = new Vector3(-backgroundWidth, 0, 0);
        centerBG = Instantiate(background, transform);
        centerBG.transform.position = new Vector3(0, 0, 0);
        rightBG = Instantiate(background, transform);
        rightBG.transform.position = new Vector3(backgroundWidth, 0, 0);
    }
    public float GetWidth() => backgroundWidth;
}
