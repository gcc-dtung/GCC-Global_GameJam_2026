using UnityEngine;

public class PlayerPushAndHoldState : PlayerBaseState
{
    public PlayerPushAndHoldState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _controller.InteractSystem.Interact();
    }

    public override void Action()
    {
        _movement.SlowMove();
        _animator.SetFloat("xVelocity", _movement.Movement * _movement.FacingDirection);
    }

    public override void ExitState()
    {
        Debug.Log("UnInterct");
        base.ExitState();
        _controller.InteractSystem.UnInteract();
    }
}
