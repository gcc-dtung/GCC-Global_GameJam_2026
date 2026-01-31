using UnityEngine;

public class PlayerWallSlideState : PlayerBaseState
{
    private float Direction;
    public PlayerWallSlideState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void Action()
    {
        // Direction = _controller.input.WallSlideAction.ReadValue<float>();
        // _movement.WallSlide(Direction);
        _movement.HandleWallSlideLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
