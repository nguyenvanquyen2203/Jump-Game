using UnityEngine;

[CreateAssetMenu]
public class CharacterDB : ScriptableObject
{
    public int indexSkin;
    public int coin;
    public Character[] characters;
    public int CharacterCount { get { return characters.Length; } }
    public Character GetCharacter(int selectedIndex) => characters[selectedIndex];
    public void BuySkin(int selectedIndex)
    {
        characters[selectedIndex].BuySkin();
    }
    public AnimatorOverrideController GetAnimator() => characters[indexSkin].animator;
    public Character GetCurrentCharacter() => characters[indexSkin];
}
