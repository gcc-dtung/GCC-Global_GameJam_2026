using System;
using UnityEngine;

public class Door : MonoBehaviour
{
   private BoxCollider2D _collider2D;
   [SerializeField] private VoidEventChannelSO LeverEvent;

   private void Awake()
   {
      _collider2D = this.GetComponent<BoxCollider2D>();
   }

   private void OnEnable()
   {
      LeverEvent.AddListener(OpenOrClosed);
   }

   private void OnDisable()
   {
      LeverEvent.RemoveListener(OpenOrClosed);
   }

   private void OpenOrClosed()
   {
      _collider2D.isTrigger = !_collider2D.isTrigger;
   }
}
