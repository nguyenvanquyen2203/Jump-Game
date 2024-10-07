using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public ParticleSystem windEffect;
    private bool isActive;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isActive = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            StartCoroutine(ShakeObject());
            isActive = false;
        }
    }
    private IEnumerator ShakeObject()
    {
        Vector3 originalPos = transform.position;
        while (originalPos.y - transform.position.y < .2f) 
        {
            transform.position -= Vector3.up * Time.deltaTime * 2f;
            yield return null;
        }
        StartCoroutine(ShakeObject2(originalPos));
    }
    private IEnumerator ShakeObject2(Vector3 targetPos)
    {
        while (targetPos.y - transform.position.y > .02f)
        {
            transform.position += Vector3.up * Time.deltaTime * 1.5f;
            yield return null;
        }
        Invoke(nameof(FallPlatform),.2f);
    }
    private void OnDisable()
    {
        transform.gameObject.SetActive(false);
    }
    private void FallPlatform()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.enabled = false;
        windEffect.Stop();
        Invoke(nameof(OnDisable), 3f);
    }
}
