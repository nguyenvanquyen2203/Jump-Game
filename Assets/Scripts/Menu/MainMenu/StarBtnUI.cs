using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBtnUI : MonoBehaviour
{
    public Sprite star;
    public Sprite starBG;
    public Image[] stars;
    public void Show(int numberStar)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < numberStar) stars[i].sprite = star;
            else stars[i].sprite = starBG;
        }
    }
}
