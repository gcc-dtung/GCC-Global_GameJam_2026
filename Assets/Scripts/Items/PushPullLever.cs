using System;
using UnityEngine;

public class PushPullLever : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    [SerializeField] private VoidEventChannelSO pushPullLeverEvent;
    private Animator _animator;
    private bool logic = true;
    public void Awake()
    {
        InteractType = TypeOfInteract.PressInteract;
        _animator = this.GetComponent<Animator>();
    }

    public void Interacted(GameObject game)
    {
        pushPullLeverEvent?.RaiseEvent();
        if (logic == true)
        {
            _animator.SetTrigger("Push");
        }
        else _animator.SetTrigger("Pull");

        logic = !logic;
    }

    public void HoldInteracted(float direction)
    {
        
    }

    public void UnInteracted()
    {
       
    }
}
