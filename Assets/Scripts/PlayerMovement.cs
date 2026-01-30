using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float Speed;
	[HideInInspector] public float Movement { get; private set; }
	Rigidbody2D rb;
	[Header("Jump")]
	[SerializeField] float JumpForce;
	[SerializeField] float caiyoteTime;
	[SerializeField] float JumpBufferTime;
	float CurrJumpBufferTime;
	public bool isGrounded{ get; private set; }
	[SerializeField] LayerMask GroundLayer;
	[SerializeField] Transform GroundCheckPos;
	[SerializeField] bool JumpBuffer;
	[Header("Gravity")]
	float gravityScale = 1f;
	float FallMultiplyer = 2f;

	[Header("Input")]
	InputAction MoveAction;
	InputAction JumpAction;
	
	[Header("Other")]
	public bool IsFacingRight = true;
	

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		MoveAction = InputSystem.actions.FindAction("Move");
		JumpAction = InputSystem.actions.FindAction("Jump");
	}
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheckPos.position, new Vector2(0.9f, 0.15f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        Input();
        TurnCheck();
        //move
        Move();
        Assist();
        JumpCurve();
        Jump();
        ReleaseJumpEarly();

    }

    private void Move()
    {
        rb.linearVelocityX = Movement * Speed;
    }

    private void Assist()
	{
		if (isGrounded)
		{
			caiyoteTime = 0.1f;
		}
		else
		{
			caiyoteTime -= Time.deltaTime;
		}
	}

	private void JumpCurve()
	{
		if (rb.linearVelocity.y >= 0.5f)
		{
			caiyoteTime = 0f;
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

	private void ReleaseJumpEarly()
	{
		if (!JumpAction.IsPressed())
		{
			if (rb.linearVelocity.y > 0)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0f);
			}
		}
	}


	private void Jump()
	{
		if (JumpBuffer)
		{
			CurrJumpBufferTime -= Time.deltaTime;
			if (CurrJumpBufferTime > 0 && (caiyoteTime > 0 || (isGrounded && JumpAction.IsPressed())))
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

	void Input()
	{
		Movement = MoveAction.ReadValue<float>();
		if (JumpAction.WasPressedThisFrame())
		{
			CurrJumpBufferTime = JumpBufferTime;
			JumpBuffer = true;

		}

	}
	void TurnCheck()
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
	}
}