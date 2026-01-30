using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerBaseState : IState
{
    protected PlayerController _controller;
    protected string _animationName;
    protected Animator _animator;
    protected PlayerMovement _movement;
    public PlayerBaseState(PlayerController controller,string _name)
    {
        _controller = controller;
        _animationName = _name;
        _animator = controller.Animators;
        _movement = controller.Movement;
    }
    
    public virtual void EnterState()
    {
        _animator.SetBool(_animationName,true);
    }

    public virtual void Action()
    {
        _movement.Move();
        _movement.HandleFlip();
    }

    public virtual void ExitState()
    {
        _animator.SetBool(_animationName,false);
    }
}
