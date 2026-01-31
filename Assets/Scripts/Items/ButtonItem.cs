
using System;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    [SerializeField] private Door _door;
    private Animator _animator;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

    private int _pressingCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PushableBlock"))
        {
            _pressingCount++;
            if (_pressingCount == 1)
            {
                _door.Open();
                Debug.Log("Button Pressed - Door Opened");

                _animator.SetTrigger("Pull");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PushableBlock"))
        {
            _pressingCount--;

            if (_pressingCount <= 0)
            {
                _pressingCount = 0; 
                _door.Close();
                Debug.Log("Button Released - Door Closed");
                _animator.SetTrigger("Push");
            }
        }
    }
}

// using System;
// using UnityEngine;
//
// public class ButtonItem : MonoBehaviour
// {
//   [SerializeField] private Door _door;
//   private Collider2D currentCollider;
//   private void OnTriggerEnter2D(Collider2D other)
//   {
//     _door?.Open();
//     Debug.Log("Push");
//   }
//
//   private void OnTriggerExit2D(Collider2D other)
//   {
//     _door?.Close();
//   }
// }
