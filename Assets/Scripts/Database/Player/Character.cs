using UnityEngine;

[System.Serializable]
public class Character
{
    public string characterName;
    public Sprite characterSprite;
    public int price;
    public void BuySkin()
    {
        price = 0;
    }
}
