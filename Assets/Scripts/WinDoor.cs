using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinDoor : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO winEvent;
   
    // Biến lưu trữ action để tham chiếu
    private InputAction _interactAction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (other.TryGetComponent(out PlayerController playerController))
        {
            _interactAction = playerController.input.InteractAction;

            if (_interactAction != null)
            {
                _interactAction.performed += OnInteract;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _interactAction != null)
        {
            _interactAction.performed -= OnInteract;
            _interactAction = null;
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        winEvent?.RaiseEvent();
        if (_interactAction != null)
        {
            _interactAction.performed -= OnInteract;
        }
       
        this.gameObject.SetActive(false);
    }
}