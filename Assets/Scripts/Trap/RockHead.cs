using System;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    public Vector2 direction;
    private Vector3 dir;
    private float distanceCheck;
    private BoxCollider2D box;
    private Animator anim;
    public LayerMask mask;
    public float delayTime;
    private float couter;
    public float speed;
    private bool isMove;
    // Start is called before the first frame update
    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        distanceCheck = speed * Time.fixedDeltaTime;
        isMove = false;
        couter = delayTime;
        dir = new Vector3(direction.x, direction.y, 0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsContact())
        {
            isMove = false;
            TakeHit();
            dir *= -1f;
        }
        if (isMove) transform.position += dir * speed * Time.fixedDeltaTime;
        if (couter > 0f)
        {
            couter -= Time.fixedDeltaTime;
            return;
        }
        else
        {
            isMove = true;
        }
    }

    private void TakeHit()
    {
        couter = delayTime;
        if (dir == Vector3.right) anim.Play("RightHit");
        if (dir == Vector3.left) anim.Play("LeftHit");
        if (dir == Vector3.up) anim.Play("TopHit");
        if (dir == Vector3.down) anim.Play("BottomHit");
    }
    private bool IsContact()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, dir, distanceCheck, mask);
    }
}
