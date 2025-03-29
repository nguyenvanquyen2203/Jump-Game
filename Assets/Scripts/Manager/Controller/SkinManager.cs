using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public int GetPriceSkin(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin, 0);
    }
    public void BuySkin(string nameSkin)
    {
        PlayerPrefs.SetInt(nameSkin, 0);
    }
}