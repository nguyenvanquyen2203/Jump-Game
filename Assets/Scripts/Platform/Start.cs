using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.enabled = true;
        anim.Play("idle");
    }
    public void Disable() { anim.enabled = false; }
}