using System;
using UnityEngine;

public class PushPullLever : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    [SerializeField] private Door _door;
    public void Awake()
    {
        InteractType = TypeOfInteract.PressInteract;
    }

    public void Interacted(GameObject game)
    {
        _door.Open();
    }

    public void HoldInteracted(float direction)
    {
        
    }

    public void UnInteracted()
    {
       
    }
}
