using UnityEngine;

public class DustPSCtrl : MonoBehaviour 
{
    [SerializeField] private PlayerMovement player;
    public void SetDust(int indexDust)
    {
        player?.SetDust(indexDust);
    }
}
