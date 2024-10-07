using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BreakBoxManager : MonoBehaviour
{
    private static BreakBoxManager instance;
    public static BreakBoxManager Instance { get { return instance; } }
    public GameObject breakBoxObj;
    public int quantity;
    private List<BreakBox> breakBoxes;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        breakBoxes = new List<BreakBox>();
        for (int i = 0; i < quantity; i++)
        {
            CreateBreakBoxEffect();
        }
    }
    public void BreakEffect(Vector3 position)
    {
        foreach (BreakBox breakBox in breakBoxes)
        {
            if (!breakBox.gameObject.activeSelf)
            {
                ActiveBreakEffect(breakBox, position);
                return;
            }
        }
        CreateBreakBoxEffect();
        quantity++;
        ActiveBreakEffect(breakBoxes[quantity - 1], position);
    }
    private void CreateBreakBoxEffect()
    {
        GameObject breakBox = Instantiate(breakBoxObj, transform);
        breakBoxes.Add(breakBox.GetComponent<BreakBox>());
        breakBox.SetActive(false);
    }
    private void ActiveBreakEffect(BreakBox _breakBox, Vector3 position)
    {
        AudioManager.Instance.PlaySFX("BrokenBox");
        _breakBox.gameObject.SetActive(true);
        _breakBox.Break(position);
    }
}
