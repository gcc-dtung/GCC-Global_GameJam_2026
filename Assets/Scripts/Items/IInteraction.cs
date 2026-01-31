using UnityEngine;

public interface IInteraction
{
   public TypeOfInteract InteractType { get; set; }
   public void Interacted(GameObject game);
   public void UnInteracted();
}

public enum TypeOfInteract
{
   NoneInteract = 0,
   HoldInteract = 1,
   PressInteract = 2
}
