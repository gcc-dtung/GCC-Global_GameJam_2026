using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerInput input { get; private set; }
    [field:SerializeField] public Animator Animators { get; private set; }
    [field:SerializeField] public PlayerMovement Movement { get; private set; }
    [field:SerializeField] public PlayerInteractSystem InteractSystem { get; private set; }
    private StateMachineManager _stateMachineManager;
    private PlayerGroundState _groundState;
    private PlayerAirState _airState;
    private PlayerJumpState _jumpState;
    private PlayerFallState _fallState;
    private PlayerPushAndHoldState _pushAndHoldState;
    private PlayerTouchInteractionState _touchInteractionState;
    private PlayerOnBoard _onBoardState;
    // private PlayerWallSlideState _slideState;
    private PlayerWallJumpState _wallJumpState;
    void Awake()
    {
        OnInit();
    }

    void OnInit()
    {
        _stateMachineManager = new StateMachineManager();
        _groundState = new PlayerGroundState(this,"Ground");
        _jumpState = new PlayerJumpState(this,"Jump");
        _fallState = new PlayerFallState(this,"Fall");
        _pushAndHoldState = new PlayerPushAndHoldState(this,"PushAndHold");
        _touchInteractionState = new PlayerTouchInteractionState(this, "Touch");
        _onBoardState = new PlayerOnBoard(this, "OnBoard");

        _wallJumpState = new PlayerWallJumpState(this, "WallJump");
        _stateMachineManager.AddTransition(_groundState,_jumpState,() => input.JumpAction.WasPressedThisFrame());
        _stateMachineManager.AddTransition(_groundState,_pushAndHoldState,() => input.InteractAction.WasPressedThisFrame() && InteractSystem.CheckInteractionItem() && InteractSystem.InteractType == TypeOfInteract.HoldInteract);
        _stateMachineManager.AddTransition(_groundState,_touchInteractionState,() => input.InteractAction.WasPressedThisFrame() && InteractSystem.CheckInteractionItem() && InteractSystem.InteractType == TypeOfInteract.PressInteract);
        _stateMachineManager.AddTransition(_groundState,_onBoardState,() => input.InteractAction.IsPressed() && InteractSystem.CheckInteractionItem() && InteractSystem.InteractType == TypeOfInteract.HoldBoard);
      
        _stateMachineManager.AddTransition(_jumpState,_fallState,() => Movement.rb.linearVelocityY <= 0.5f || !input.JumpAction.IsPressed());
        _stateMachineManager.AddTransition(_fallState,_jumpState,() => Movement.IsGrounded && input.JumpAction.IsPressed());
        _stateMachineManager.AddTransition(_fallState,_groundState,() => !Movement.JumpBuffer && Movement.IsGrounded);
        

        _stateMachineManager.AddTransition(_pushAndHoldState,_groundState,() => !input.InteractAction.IsPressed() || !InteractSystem.CheckInteractionItem());
        _stateMachineManager.AddTransition(_onBoardState,_groundState,() => !input.InteractAction.IsPressed() || !InteractSystem.CheckInteractionItem());
        _stateMachineManager.AddTransition(_pushAndHoldState,_fallState,() => !Movement.IsGrounded);
        
        _stateMachineManager.AddTransition(_touchInteractionState,_groundState,() => true);
        // _slideState = new PlayerWallSlideState(this, "WallSlide");
        // _stateMachineManager.AddTransition(_fallState,_slideState,() => Movement.IsOnWall);
        // _stateMachineManager.AddTransition(_slideState, _wallJumpState, () => input.JumpAction.WasPressedThisFrame());
        // _stateMachineManager.AddTransition(_slideState, _fallState, () => !Movement.IsOnWall || (!Movement.IsGrounded && Mathf.Abs(Movement.rb.linearVelocity.x) > 0.1f && Movement.Movement != 0));
        // _stateMachineManager.AddTransition(_slideState, _groundState, () => Movement.IsGrounded);
        // _stateMachineManager.AddTransition(_wallJumpState, _fallState, () => Movement.rb.linearVelocity.y <= 0f);
        // _stateMachineManager.AddTransition(_wallJumpState, _slideState, () => Movement.IsOnWall && Movement.rb.linearVelocity.y < 0);
        

        
    }

    private void Start()
    {
        _stateMachineManager.SetState(_groundState);
    }

    private void Update()
    {
        _stateMachineManager.Tick();
        Movement.SetUpMovement(input.MoveAction);
        Movement.Jump(input.JumpAction);
    }

    public void CompleteAnimation()
    {
        IState currentState = _stateMachineManager.GetCurrentState();
        currentState.AnimationDone = true;
    }
}
