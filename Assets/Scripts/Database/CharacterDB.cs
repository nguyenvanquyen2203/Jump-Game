using UnityEngine;

[CreateAssetMenu]
public class CharacterDB : ScriptableObject
{
    public Character[] characters;
    public int CharacterCount { get { return characters.Length; } }
    public Character GetCharacter(int selectedIndex) => characters[selectedIndex];
}
