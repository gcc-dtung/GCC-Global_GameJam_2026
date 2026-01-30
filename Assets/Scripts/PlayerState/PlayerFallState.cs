using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void Action()
    {
        base.Action();
        _movement.JumpCurve();
    }
}
