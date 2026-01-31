using UnityEngine;

public class PlayerOnBoard : PlayerBaseState
{
    public PlayerOnBoard(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _controller.InteractSystem.Interact();
        _controller.Movement.StopMove();
    }

    public override void Action()
    {
        _controller.InteractSystem.HoldInteract(_controller.Movement.Movement);
    }

    public override void ExitState()
    {
        base.ExitState();
        _controller.InteractSystem.UnInteract();
    }
}
