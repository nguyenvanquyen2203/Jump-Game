using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public ParticleSystem windEffect;
    public GameObject bonusItem;
    private bool isActive;
    private Vector3 originalPos;
    private bool isSpawn;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isActive = true;
        originalPos = transform.position;
        isSpawn = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            StartCoroutine(ShakeObject());
            isActive = false;
        }
        if (collision.gameObject.CompareTag("Trap") && !isSpawn)
        {
            isSpawn = true;
            CancelInvoke();
            GameObject bonusObj = Instantiate(bonusItem, transform.position, transform.rotation);
            LeanTween.move(bonusObj, originalPos, .5f).setEase(LeanTweenType.easeInOutQuad);
            CollectionManager.Instance.ActivePoolCtrl(CollectionManager.PoolType.Explosion, transform.position);
            AudioManager.Instance.PlaySFX("Explosion");
            gameObject.SetActive(false);
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
