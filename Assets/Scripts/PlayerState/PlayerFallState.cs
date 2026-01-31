using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private PlayerSFX psfx;
    public PlayerFallState(PlayerController controller, string _name) : base(controller, _name)
    {
        psfx = _controller.gameObject.GetComponent<PlayerSFX>();
    }

    public override void Action()
    {
        base.Action();
        _movement.JumpCurve();
    }

    public override void ExitState()
    {
        base.ExitState();
        psfx.Land();
    }
}
