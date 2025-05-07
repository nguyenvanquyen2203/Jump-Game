using UnityEngine;

[CreateAssetMenu]
public class CharacterDB : ScriptableObject
{
    public Character[] characters;
    public int CharacterCount { get { return characters.Length; } }
    public Character GetCharacter(int selectedIndex) => characters[selectedIndex];
    public AnimatorOverrideController GetAnimator(int indexSkin) => characters[indexSkin].animator;
    public Character GetCurrentCharacter(int indexSkin) => characters[indexSkin];
}
