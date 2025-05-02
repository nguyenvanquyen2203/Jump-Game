using UnityEngine;

public class StarEffect : MonoBehaviour
{
    private Animator anim;
    private StarCtrl ctrl;
    private bool isStar;
    private void Awake()
    {
        if (anim == null) anim = GetComponent<Animator>();
    }
    public ParticleSystem starEffect;
    public void ActiveStar(bool _isActive, StarCtrl _ctrl)
    {
        if (ctrl == null) ctrl = _ctrl;
        if (anim == null) anim = GetComponent<Animator>();
        if (_isActive)
        {
            anim.Play("Appear");
            isStar = true;
        }
        else
        {
            anim.Play("Disappear");
            isStar = false;
        }
    }
    public void ActiveStarEffect()
    {
        if (isStar)
        {
            starEffect.gameObject.SetActive(true);
            starEffect.Play();
        }
        ctrl.ShowNextStar();
    }
}
