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
        _stateMachineManager.AddTransition(_groundState,_jumpState,() => input.JumpAction.WasPressedThisFrame());
        _stateMachineManager.AddTransition(_jumpState,_fallState,() => Movement.rb.linearVelocityY <= 0.5f || !input.JumpAction.IsPressed());
        _stateMachineManager.AddTransition(_fallState,_jumpState,() => Movement.IsGrounded && input.JumpAction.IsPressed());
        _stateMachineManager.AddTransition(_fallState,_groundState,() => !Movement.JumpBuffer && Movement.IsGrounded);
        _stateMachineManager.AddTransition(_groundState,_pushAndHoldState,() => input.InteractAction.IsPressed() && InteractSystem.CheckInteractionItem());
        _stateMachineManager.AddTransition(_pushAndHoldState,_groundState,() => !input.InteractAction.IsPressed() || !InteractSystem.CheckInteractionItem());
        _stateMachineManager.AddTransition(_pushAndHoldState,_fallState,() => !Movement.IsGrounded);
        

        
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
}
