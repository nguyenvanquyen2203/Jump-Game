using System.Collections.Generic;
using UnityEngine;

public class PointToPoint : Subject
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
    public float speed;
    private bool isOn;
    public int direction = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        isOn = true;
    }
    void Start()
    {
        direction = -1;
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
                    if (!isOn)
                    {
                        state = State.Inactive;
                    }
                    targetPoint++;
                    if (targetPoint == points.Count) targetPoint = 0;
                    if (transform.position.x - points[targetPoint].position.x > 0) direction = -1;
                    if (transform.position.x - points[targetPoint].position.x < 0) direction = 1;
                    NotifyObserver();
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
}
