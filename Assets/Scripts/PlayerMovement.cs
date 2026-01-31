using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] [SerializeField] float Speed;
    [SerializeField] private float SlowMultiplyer;
    [HideInInspector] public float Movement { get; private set; }
    public Rigidbody2D rb { get; private set; }

    [Header("Jump")] [SerializeField] float JumpForce;
    [field: SerializeField] public float CoyoteTime { get; private set; }
    [SerializeField] float JumpBufferTime;
    [field:SerializeField] public float CurrJumpBufferTime { get; private set; }
    public bool IsGrounded { get; private set; }
    public LayerMask GroundLayer;
    [SerializeField] Transform GroundCheckPos;
    public bool JumpBuffer { get; private set; }
    [Header("Gravity")] float gravityScale = 1f;
    float FallMultiplyer = 2f;
    
    [Header("Other")] public bool IsFacingRight = true;
    
    [Header("WallJump")]
    [SerializeField] private Transform firstWallCheckPoint;
    [SerializeField] private Transform secondWallCheckPoint;
    [SerializeField] float wallCheckDistance;
    [SerializeField] private Vector2 WallJumpForce;
    [SerializeField] private float WallJumpCoyoteTimeMax;
    [SerializeField] private float WallJumpCounter;
    [SerializeField] private float WallSlideMulitiphy;
    public bool IsOnGround {get; private set;}
    [field:SerializeField] public bool IsOnWall {get; private set;}
    public float FacingDirection { get; private set; } = 1;
    [Header("Wall Stick Settings")]
    [SerializeField] private float wallStickTime = 0.25f; 
    private float wallStickTimer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        IsGrounded = Physics2D.OverlapCapsule(GroundCheckPos.position, new Vector2(0.74f, 0.15f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        WallCheck();
        Assist();
    }

    #region WallJumpHandle
    public void WallCheck()
    {
        IsOnWall = Physics2D.Raycast(firstWallCheckPoint.position,transform.right,wallCheckDistance,GroundLayer) 
                   && Physics2D.Raycast(secondWallCheckPoint.position,transform.right,wallCheckDistance,GroundLayer);
    }
    
    public void HandleWallSlideLogic()
    {
        if (Movement == 0 || (int)Mathf.Sign(Movement) == (int)FacingDirection)
        {
            wallStickTimer = wallStickTime;
            WallSlide(-1); 
        }
        else 
        {
            if (wallStickTimer > 0)
            {
                wallStickTimer -= Time.deltaTime;
                rb.linearVelocity = Vector2.zero; 
            }
            else
            {
                rb.linearVelocity = new Vector2(Movement * Speed, rb.linearVelocity.y);
            }
        }
    }
    
    public void PerformWallJump()
    {
        float jumpDir = -FacingDirection;
        wallStickTimer = 0;
        Vector2 force = new Vector2(WallJumpForce.x * jumpDir, WallJumpForce.y);
        rb.linearVelocity = force;
        if (jumpDir > 0 && !IsFacingRight) HandleFlip();
        else if (jumpDir < 0 && IsFacingRight) HandleFlip();
    }

    public void WallSlide(float Direction)
    {
        Debug.Log(Direction);
        if (Direction >= 1f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY);
            return; 
        }
        rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * WallSlideMulitiphy);
    }

    #endregion
    
    #region JumpHandle

    public void JumpCurve()
    {
        if (rb.linearVelocity.y >= 0.5f)
        {
            CoyoteTime = 0f;
        }
        else if (rb.linearVelocity.y <= 0.5f)
        {
            rb.gravityScale = gravityScale * FallMultiplyer;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }

    public void ReleaseJumpEarly()
    {
        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0f);
        }
    }
    public void Jump(InputAction JumpAction)
    {
        if (JumpBuffer)
        {
            CurrJumpBufferTime -= Time.deltaTime;
            if (CurrJumpBufferTime > 0 && (CoyoteTime > 0 || (IsGrounded && JumpAction.IsPressed())))
            {
                JumpBuffer = false;
                rb.gravityScale = gravityScale;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            }
            else if (CurrJumpBufferTime <= 0)
            {
                JumpBuffer = false;
            }
        }
    }
    


    #endregion

    #region MoveHandle


    public void StopMove()
    {
        rb.linearVelocityX = 0f;
    }

    public void SlowMove()
    {
        rb.linearVelocityX = Movement * Speed * SlowMultiplyer;
    }

    public void Assist()
    {
        if (IsGrounded)
        {
            CoyoteTime = 0.1f;
        }
        else
        {
            CoyoteTime -= Time.deltaTime;
        }
    }

    public void Move()
    {
        rb.linearVelocityX = Movement * Speed;
    }

    #endregion
    
    #region SetUp

    public void SetUpMovement(InputAction MoveAction)
    {
        Movement = MoveAction.ReadValue<float>();
    }

    public void SetUpJump()
    {
        CurrJumpBufferTime = JumpBufferTime;
        JumpBuffer = true;
    }

    #endregion

    #region HandleFlip

    public void HandleFlip()
    {
        if (Movement > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (Movement < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        if (IsFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        FacingDirection *= -1;
    }

    #endregion
    
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(firstWallCheckPoint.position,transform.right*wallCheckDistance);
        Gizmos.DrawRay(secondWallCheckPoint.position,transform.right*wallCheckDistance);
    }
    
    

  
}
