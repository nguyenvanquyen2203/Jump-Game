using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;
    // Start is called before the first frame update
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    void Start()
    {
        m_animator.runtimeAnimatorController = SkinManager.Instance.GetAnimator();
    }
}
