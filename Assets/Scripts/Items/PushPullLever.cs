using System;
using UnityEngine;

public class PushPullLever : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    [SerializeField] private VoidEventChannelSO pushPullLeverEvent;
    public void Awake()
    {
        InteractType = TypeOfInteract.PressInteract;
    }

    public void Interacted(GameObject game)
    {
        pushPullLeverEvent?.RaiseEvent();
    }

    public void HoldInteracted(float direction)
    {
        
    }

    public void UnInteracted()
    {
       
    }
}
