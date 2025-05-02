using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction movement;
    private InputAction jumpAct;
    private Rigidbody2D m_rb;
    private Animator m_animator;
    private BoxCollider2D m_collider;
    [SerializeField] private List<ParticleSystem> dustPSes;
    [SerializeField] private ParticleSystem jumpDust;
    private int currentDust;
    private bool jumped;
    private bool isGrounded;
    private Vector2 moveVector;
    private string state;
    [SerializeField] private float delayGroundDust;
    private float couter;

    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_jumpHeight;
    private float multiGraviry;
    private Vector2 bonusVector;
    // Start is called before the first frame update
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        movement = InputCtrl.Instance.GetInput().Movement.LeftRight;
        jumpAct = InputCtrl.Instance.GetInput().Movement.Jump;
        jumpAct.performed += JumpActions_performed;
    }
    private void OnDisable()
    {
        jumpAct.performed -= JumpActions_performed;
    }
    void Start()
    {
        couter = delayGroundDust;
        bonusVector = Vector2.zero;
        state = PlayerAnim.PlayerAnimIdle;
        jumped = false;
        isGrounded = true;
        multiGraviry = m_rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (couter < delayGroundDust) couter += Time.deltaTime;
        if (IsGround())
        {
            if (!isGrounded)
            {
                jumpDust.Play();
                isGrounded = true;
                couter = 0f;
            }
        }
        else isGrounded = false;
        float horizontal = movement.ReadValue<float>();
        if (bonusVector.y < 0f) moveVector = new Vector2(horizontal * m_speed, 0f);
        else moveVector = new Vector2(horizontal * m_speed, m_rb.velocity.y - bonusVector.y);
        if (isGrounded && horizontal != 0f && couter >= delayGroundDust)
        {
            dustPSes[currentDust].Play();
            couter = 0f;
        }
        //if (isGrounded && m_rb.velocity.y < -0.1f) jumpDust.Play();
        #region Flip Player
        if (horizontal > 0f) transform.localScale = Vector3.one;
        if (horizontal < 0f) transform.localScale = new Vector3(-1f, 1f, 1f);
        #endregion

        m_rb.velocity = moveVector + bonusVector;
        #region Change Player Anim State
        if (horizontal == 0) state = PlayerAnim.PlayerAnimIdle;
        else state = PlayerAnim.PlayerAnimRun;
        if (!isGrounded)
        {
            if (moveVector.y > 0)
            {
                if (!jumped) state = PlayerAnim.PlayerAnimJump;
                else state = PlayerAnim.PlayerAnimDoubleJump;
            }
            else state = PlayerAnim.PlayerAnimFall;
        }
        #endregion
        ChangeAnimState(state);
    }
    public void ChangeAnimState(string _state) => m_animator.Play(_state);
    private void Jump()
    {
        AudioManager.Instance.PlaySFX("Jump");
        moveVector = new Vector2(m_rb.velocity.x, Mathf.Sqrt(2 * m_jumpHeight * 9.81f * multiGraviry));
        m_rb.velocity = moveVector + bonusVector;
    }
    private void JumpActions_performed(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            jumped = false;
            Jump();
        }
        else if (!jumped)
        {
            jumped = true;
            Jump();
        }
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(m_collider.bounds.center, m_collider.bounds.size, 0f, Vector2.down, .1f, GroundLayer);
    }
    public void Attack()
    {
        AudioManager.Instance.PlaySFX("Hit");
        jumped = false;
        m_rb.velocity = new Vector2(m_rb.velocity.x, Mathf.Sqrt(2 * m_jumpHeight * 2/3 * 9.81f * multiGraviry));
    }
    public void SetBonus(Vector2 _bonusVector)
    {
        bonusVector = _bonusVector;
    }
    public void SetDust(int indexDust) => currentDust = indexDust;

    public void DisableInput()
    {
        jumpAct.performed -= JumpActions_performed;
    }

    public void EnableInput()
    {
        jumpAct.performed += JumpActions_performed;
    }
}