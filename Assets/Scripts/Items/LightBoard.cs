using System;
using UnityEngine;

public class LightBoard : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    [SerializeField] private RotateObject _rotateObject;
    private void Start()
    {
        InteractType = TypeOfInteract.HoldBoard;
    }
    
    
    public void Interacted(GameObject game)
    {
       _rotateObject.SetUp();
    }

    public void HoldInteracted(float direction)
    {
       _rotateObject.Rotate(direction);
    }


    public void UnInteracted()
    {

    }
}
