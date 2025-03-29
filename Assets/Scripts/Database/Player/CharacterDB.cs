using UnityEngine;

[CreateAssetMenu]
public class CharacterDB : ScriptableObject
{
    public int indexSkin;
    public Character[] characters;
    public int CharacterCount { get { return characters.Length; } }
    public Character GetCharacter(int selectedIndex) => characters[selectedIndex];
    public void BuySkin(int selectedIndex)
    {
        characters[selectedIndex].BuySkin();
    }
}
