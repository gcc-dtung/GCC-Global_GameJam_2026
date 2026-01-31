using UnityEngine;

public interface IState
{
    public bool AnimationDone { get; set; }
    public void EnterState();
    public void Action();
    public void ExitState();
}
