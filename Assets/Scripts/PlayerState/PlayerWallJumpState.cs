using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    public PlayerWallJumpState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _movement.PerformWallJump();
    }

    public override void Action()
    {
        _movement.JumpCurve();
    }
}
