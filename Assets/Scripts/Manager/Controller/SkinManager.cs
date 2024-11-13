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
    private void Start()
    {
        /*PlayerPrefs.SetInt("NinjaFrog", 2);
        PlayerPrefs.SetInt("PinkMan", 100);
        PlayerPrefs.SetInt("VirtualGuy", 200);*/
    }
}
