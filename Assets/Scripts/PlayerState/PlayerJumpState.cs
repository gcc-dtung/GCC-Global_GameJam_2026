using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _movement.SetUpJump();
    }

    public override void Action()
    {
        base.Action();
        _movement.JumpCurve();
    }

    public override void ExitState()
    {
        _movement.ReleaseJumpEarly();
        base.ExitState();
    }
}
