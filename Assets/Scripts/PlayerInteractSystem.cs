
using System;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    private IInteraction _interaction;

    [field: SerializeField]
    public TypeOfInteract InteractType { get; private set; }

    [SerializeField] 
    private bool CheckItems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_interaction != null) return;
        if (!other.CompareTag("Item") && !other.CompareTag("PushableBlock") ) return;

        if (other.TryGetComponent(out IInteraction interaction))
        {
            SetInteraction(interaction);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_interaction != null) return;
        if (!other.CompareTag("Item") && !other.CompareTag("PushableBlock") ) return;

        if (other.TryGetComponent(out IInteraction interaction))
        {
            SetInteraction(interaction);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (_interaction == null) return;

        if (other.TryGetComponent(out IInteraction interaction) && interaction == _interaction)
        {
            ClearInteract();
        }
    }
    
    private void SetInteraction(IInteraction interaction)
    {
        _interaction = interaction;
        InteractType = interaction.InteractType;
        CheckItems = true;
    }

    public bool CheckInteractionItem()
    {
        if (_interaction != null && _interaction.Equals(null))
        {
            ClearInteract();
            return false;
        }
        return CheckItems;
    }

    public void Interact()
    {
        if (CheckInteractionItem())
        {
            _interaction?.Interacted(gameObject);
        }
    }

    public void HoldInteract(float multiplier)
    {
        if (CheckInteractionItem())
        {
            _interaction?.HoldInteracted(multiplier);
        }
    }

    public void UnInteract()
    {
        _interaction?.UnInteracted();
    }

    private void ClearInteract()
    {
        if (_interaction != null && !_interaction.Equals(null))
        {
            _interaction.UnInteracted();
        }

        _interaction = null;
        InteractType = TypeOfInteract.NoneInteract;
        CheckItems = false;
    }
}

// using System;
// using UnityEngine;
//
// public class PlayerInteractSystem : MonoBehaviour
// {
//     private IInteraction _interaction;
//
//     [field: SerializeField]
//     public TypeOfInteract InteractType { get; private set; }
//
//     [SerializeField] 
//     private bool CheckItems;
//
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         // đã có item rồi thì bỏ qua
//         if (_interaction != null) return;
//
//         if (!other.CompareTag("Item")) return;
//
//         if (other.TryGetComponent(out IInteraction interaction))
//         {
//             _interaction = interaction;
//             InteractType = interaction.InteractType;
//             CheckItems = true;
//         }
//     }
//
//     private void OnTriggerStay2D(Collider2D other)
//     {
//         if (_interaction != null) return;
//
//         if (!other.CompareTag("Item")) return;
//
//         if (other.TryGetComponent(out IInteraction interaction))
//         {
//             _interaction = interaction;
//             InteractType = interaction.InteractType;
//             CheckItems = true;
//         }
//     }
//
//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (_interaction == null) return;
//
//         if (other.TryGetComponent(out IInteraction interaction)
//             && interaction == _interaction)
//         {
//             ClearInteract();
//         }
//     }
//
//     public bool CheckInteractionItem() => CheckItems;
//
//     public void Interact()
//     {
//         _interaction?.Interacted(gameObject);
//     }
//
//     public void HoldInteract(float multiplier)
//     {
//         _interaction?.HoldInteracted(multiplier);
//     }
//
//     public void UnInteract()
//     {
//         _interaction?.UnInteracted();
//         ClearInteract();
//     }
//
//     private void ClearInteract()
//     {
//         _interaction?.UnInteracted();
//         _interaction = null;
//         InteractType = TypeOfInteract.NoneInteract;
//         CheckItems = false;
//     }
// }