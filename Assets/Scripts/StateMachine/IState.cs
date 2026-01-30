using UnityEngine;

public interface IState
{
    public void EnterState();
    public void Action();
    public void ExitState();
}
