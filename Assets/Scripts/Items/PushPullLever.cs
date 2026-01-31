using System;
using UnityEngine;

public class PushPullLever : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    [SerializeField] private VoidEventChannelSO LeverEvent;

    public void Awake()
    {
        InteractType = TypeOfInteract.PressInteract;
    }

    public void Interacted(GameObject game)
    {
        LeverEvent?.RaiseEvent();
    }

    public void UnInteracted()
    {
       
    }
}
