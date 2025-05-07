using UnityEngine;

public class RockHead : PlatformSubject, IMovePlatform
{
    private Vector3 dir;
    private float distanceCheck;
    private BoxCollider2D box;
    private Animator anim;
    public LayerMask mask;
    public float delayTime;
    private float couter;
    private bool isMove;

    [field: SerializeField] public Vector2 direction { get; set; }
    [field: SerializeField] public float speed { get; set; }

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
            ChangeDirection();
        }
        if (isMove) transform.position += dir * speed * Time.fixedDeltaTime;
        if (couter > 0f)
        {
            couter -= Time.fixedDeltaTime;
            if (couter <= 0f) NotifyObserver(speed * direction);
        } 
        else isMove = true;
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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(box.bounds.center, box.bounds.size, 0f, dir, distanceCheck, mask);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Ground")) return true;
        }
        return false;
    }

    public void ChangeDirection()
    {
        dir *= -1f;
        direction *= -1f;
        if (isMove)
        {
            NotifyObserver(speed * direction);
        }
        else
        {
            NotifyObserver(Vector2.zero);
        }
        //NotifyObserver();
    }
}
