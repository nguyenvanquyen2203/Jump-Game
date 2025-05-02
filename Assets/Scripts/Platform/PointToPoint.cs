using System.Collections.Generic;
using UnityEngine;

public class PointToPoint : PlatformSubject, IMovePlatform
{
    private enum State
    {
        Active, 
        Inactive
    }
    private State state;
    private Animator animator;
    private int targetPoint;
    public List<Transform> points;
    private bool isOn;
    //public int direction = 1;

    public Vector2 direction { get; set; }
    [field: SerializeField] public float speed { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        isOn = true;
    }
    void Start()
    {
        UpdateDirection();
        targetPoint = 0;
        state = State.Active;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (points.Count > 0)
        {
            if (state == State.Active)
            {
                if ((transform.position - points[targetPoint].position).sqrMagnitude < .01f)
                {
                    transform.position = points[targetPoint].position;
                    if (!isOn)
                    {
                        state = State.Inactive;
                    }
                    targetPoint++;
                    if (targetPoint == points.Count) targetPoint = 0;
                    ChangeDirection();
                }
                else transform.position = Vector3.MoveTowards(transform.position, points[targetPoint].position, speed * Time.fixedDeltaTime);
            }
            else if (animator.enabled)
            {
                animator.enabled = false;
            }
        }
    }
    public void TurnOn()
    {
        state = State.Active;
        isOn = true;
        animator.enabled = true;
    }
    public void TurnOff()
    {
        isOn = false;
    }

    public void ChangeDirection()
    {
        UpdateDirection();
        NotifyObserver(direction * speed);
    }
    private void UpdateDirection()
    {
        direction = (points[targetPoint].position - transform.position).normalized;
        /*if (transform.position.x - points[targetPoint].position.x > 0) direction = Vector2.left;
        if (transform.position.x - points[targetPoint].position.x < 0) direction = Vector2.right;
        if (transform.position.y - points[targetPoint].position.y > 0) direction = Vector2.down;
        if (transform.position.y - points[targetPoint].position.y < 0) direction = Vector2.up;*/
    }
}
