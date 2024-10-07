using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;
    public List<AnimatorOverrideController> animators;

    // Start is called before the first frame update
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    void Start()
    {
        m_animator.runtimeAnimatorController = animators[GetCharacterIndex()];
    }
    public int GetCharacterIndex()
    {
        if (!PlayerPrefs.HasKey("selectedIndex")) return 0;
        return PlayerPrefs.GetInt("selectedIndex");
    }
}
