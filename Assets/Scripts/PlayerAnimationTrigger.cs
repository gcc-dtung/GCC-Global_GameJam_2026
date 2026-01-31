using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController _controller; 
    public void AnimationDone()
    {
        _controller.CompleteAnimation();
    }
}
