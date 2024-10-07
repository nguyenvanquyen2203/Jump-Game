using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int life;
    private int baseLife;
    [SerializeField] private TextMeshProUGUI lifeText;
    private static PlayerHealth instance;
    public static PlayerHealth Instance { get { return instance; } }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        baseLife = life;
        ChangeTextLife(life);
    }
    public void Hurt()
    {
        life--;
        if (life < 0)
        {
            ChangeTextLife(0);
            GameManager.Instance.GameOver(false);
        }
        else
        {
            AudioManager.Instance.PlaySFX("Death");
            ChangeTextLife(life);
            GameManager.Instance.Death();
        }
    }
    public void ChangeTextLife(int _life)
    {
        lifeText.text = "X " + _life;
    }
    public void GetHeart()
    {
        if (life < baseLife) life++;
        ChangeTextLife(life);
    }
}
