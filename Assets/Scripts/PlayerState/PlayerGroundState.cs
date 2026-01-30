using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerController controller, string _name) : base(controller, _name)
    {
    }

    public override void Action()
    {
        base.Action();
        _animator.SetFloat("xVelocity",_movement.rb.linearVelocityX);
    }
}
