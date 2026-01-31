using UnityEngine;

public class PlayerTouchInteractionState : PlayerBaseState
{
    public PlayerTouchInteractionState(PlayerController controller, string _name) : base(controller, _name)
    {
    }
    
    public override void EnterState()
    {
        base.EnterState();
        _controller.InteractSystem.Interact();
    }

    public override void Action()
    {
        _movement.StopMove();
    }

    public override void ExitState()
    {
        base.ExitState();
        _controller.InteractSystem.UnInteract();
    }
}
