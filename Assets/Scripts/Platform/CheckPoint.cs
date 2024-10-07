using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    private bool isActive;
    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        isActive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            isActive = true;
            anim.enabled = true;
            anim.Play("flagOut");
            GameManager.Instance.UpdateSpawnPoint(transform);
            AudioManager.Instance.PlaySFX("CheckPoint");
        }
    }
}