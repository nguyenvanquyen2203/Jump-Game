using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    public void SetInteractable(bool isInteractable)
    {
        if (btn == null) { btn = GetComponent<Button>(); }
        btn.interactable = isInteractable;
    }
    public void SetText(string newText) => text.text = "+ " + newText;
}
