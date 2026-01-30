using System;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField] private Transform checkPoint;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask itemLayer;
    private Collider2D items;
    public bool CheckInteractionItem()
    {
        items = Physics2D.OverlapCircle(checkPoint.position,checkRadius,itemLayer);
        if (items == null) return false;
        return true;
    }

    public void Interact()
    {
        if(items == null) return;
        if (items.TryGetComponent<IInteraction>(out var interaction))
        {
            interaction.Interacted(this.gameObject);
        }
    }

    public void UnInteract()
    {
        if(items.TryGetComponent<IInteraction>(out var  interaction))
        interaction.UnInteracted();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkPoint.position,checkRadius);
    }
}
