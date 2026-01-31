using System;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField] private Transform checkPoint;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask itemLayer;
    private Collider2D items;

    [field:SerializeField]public TypeOfInteract InteractType { get; private set; }
    
    public bool CheckInteractionItem()
    {
        items = Physics2D.OverlapCircle(checkPoint.position,checkRadius,itemLayer);
        if (items == null) return false;
        InteractType = items.GetComponent<IInteraction>().InteractType;
        return true;
    }

    public void Interact()
    {
        if(items == null) { return;}
        if (items.TryGetComponent<IInteraction>(out var interaction))
        {
            interaction.Interacted(this.gameObject);
        }
    }

    public void UnInteract()
    {
        if(items.TryGetComponent<IInteraction>(out var  interaction))
        interaction.UnInteracted();
        InteractType = TypeOfInteract.NoneInteract;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkPoint.position,checkRadius);
    }
}
