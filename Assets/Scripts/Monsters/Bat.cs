using UnityEngine;

public class Bat : FlyingMonster
{
    private Vector3 centerPos;
    [SerializeField] private float restTime;
    //[SerializeField] private Vector2 moveSpace;
    private bool lockMove;
    private Vector3 moveVector;
    private float restCountDown;
    private bool isIdle;
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        centerPos = transform.position;
        restCountDown = 0;
        moveVector = Vector3.zero;
        isIdle = true;
        lockMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (restCountDown > 0) restCountDown -= Time.deltaTime;
        else
        {
            if (MoveToPoint(centerPos + new Vector3(moveVector.x, Mathf.Clamp(moveVector.y, -moveSpace.y, 0f), moveVector.z)))
            {
                if (moveVector.y > 0f)
                {
                    isIdle = true;
                    ChangeState("cellingIn");
                    RunAnim();
                    restCountDown = restTime;
                }
                moveVector = new Vector3(Random.Range(-moveSpace.x, moveSpace.x), Random.Range(-moveSpace.y, moveSpace.y * 1 / 2), 0f);
                FlipMonster(-transform.position + centerPos + moveVector);
            }
            else if (isIdle)
            {
                ChangeState("cellingOut");
                RunAnim();
                isIdle = false;
            }
        }
    }

    private void FlipMonster(Vector3 vector3)
    {
        if (vector3.x < 0f) transform.localScale = new Vector3(1, 1, 1);
        if (vector3.x > 0f) transform.localScale = new Vector3(-1, 1, 1);
    }

    private bool MoveToPoint(Vector3 targetPos)
    {
        if ((transform.position - targetPos).sqrMagnitude < .01f) return true;
        if (!lockMove) transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        return false;
    }
    protected void ChangeDirection()
    {
        float moveTime = 0;
        if (moveVector.y > 0) moveTime = restTime;
        moveVector = new Vector3(Random.Range(-moveSpace.x, moveSpace.x), Random.Range(-moveSpace.y, moveSpace.y * 1 / 2), 0f);
        Vector2 targetPos = centerPos + new Vector3(moveVector.x, Mathf.Clamp(moveVector.y, -moveSpace.y, 0f), moveVector.z);
        base.ChangeDirection(-transform.position + new Vector3(targetPos.x, targetPos.y, transform.position.z));
        if (moveTime != 0) moveTime = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).magnitude;
        Invoke(nameof(ChangeDirection), moveTime);
    }
    protected override void LockMove()
    {
        lockMove = true;
    }
    public override void UnlockMove()
    {
        lockMove = false;
    }
}