using UnityEngine;

public class ParticalChild : MonoBehaviour
{
    private void OnDisable()
    {
        Invoke(nameof(DisableParent), .2f);
    }
    private void DisableParent() => transform.parent.gameObject.SetActive(false);
}
