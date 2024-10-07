using UnityEngine;
using UnityEngine.UI;

public class VolumnCtrl : MonoBehaviour
{
    [SerializeField] private Slider volumnSlider;
    private float volumn;
    void Start()
    {
        if (PlayerPrefs.HasKey("volumn")) LoadVolumn();
        else SetVolumn();
    }
    public void SetVolumn()
    {
        volumn = volumnSlider.value;
        AudioManager.Instance.SetVolumn(volumn);
        SaveVolumn();
    }
    public void SaveVolumn() => PlayerPrefs.SetFloat("volumn", volumn);
    public void LoadVolumn()
    {
        volumn = PlayerPrefs.GetFloat("volumn");
        volumnSlider.value = volumn;
    } 
}
