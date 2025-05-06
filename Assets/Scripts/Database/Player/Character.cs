using UnityEngine;

[System.Serializable]
public class Character
{
    public int id;
    public string characterName;
    public Sprite characterSprite;
    public AnimatorOverrideController animator;
    public Character(string characterName, Sprite characterSprite, AnimatorOverrideController animator)
    {
        this.characterName = characterName;
        this.characterSprite = characterSprite;
        this.animator = animator;
    }
}
