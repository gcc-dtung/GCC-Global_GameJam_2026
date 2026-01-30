using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void Action()
    {
        base.Action();
        _movement.JumpCurve();
    }
}
