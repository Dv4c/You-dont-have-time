using UnityEngine;

public class MainHero : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        Run,
        FallingEnd,
        FallingCont
    }

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private float moveInput; 
    private bool isGrounded; 
    private PlayerState currentState;
    
    public bool IsActive { get; private set; } = true;

    void Start()
    {
        currentState = PlayerState.Idle; 
    }

    void FixedUpdate()
    {
        if (IsActive == false) 
            return;
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (Mathf.Abs(moveInput) == 1f)
            transform.localScale = new Vector3(moveInput, 1, 1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        moveInput = Input.GetAxisRaw("Horizontal");
        
        UpdateState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
            G.Audio.Play(G.Audio.Sounds.Jump,0.05f);
        }
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                if (!isGrounded)
                    SetState(PlayerState.FallingCont);
                
                else if (Mathf.Abs(moveInput) > 0)
                {
                    SetState(PlayerState.Run);
                }
                break;

            case PlayerState.Run:
                if (!isGrounded)
                {
                    SetState(PlayerState.FallingCont);
                }
                else if (Mathf.Abs(moveInput) == 0 && isGrounded)
                {
                    SetState(PlayerState.Idle);
                }
                 
                break;
            
            case PlayerState.FallingCont:
                if (isGrounded)
                {
                    SetState(PlayerState.FallingEnd);
                }
                break;
            case PlayerState.FallingEnd:
                SetState(PlayerState.Idle);
                break;
        }
    }

    void SetState(PlayerState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        
        switch (currentState)
        {
            case PlayerState.Idle:
                animator.SetInteger("State", 0);
                break;
            case PlayerState.Run:
                animator.SetInteger("State", 1);
                break;
            case PlayerState.FallingEnd:
                animator.SetInteger("State", 3);
                break;
            case PlayerState.FallingCont:
                animator.SetInteger("State", 4);
                break;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }

    public void Enable()
    {
        IsActive = true;
    }
    
    public void Disable()
    {
        IsActive = false;
        rb.linearVelocity = Vector2.zero;
    }
    
    public bool IsPlayerMoved()
    {
        if (IsActive == false)
            return false;
        
        return Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 ||
               Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetKeyDown(KeyCode.Space);
    }
}