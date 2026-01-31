using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private PlayerSFX psfx;
    public PlayerJumpState(PlayerController controller, string _name) : base(controller, _name)
    {
        psfx = _controller.gameObject.GetComponent<PlayerSFX>();
    }

    public override void EnterState()
    {
        base.EnterState();
        _movement.SetUpJump();
        psfx.Jump();
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
