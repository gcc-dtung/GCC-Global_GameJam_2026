using System;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
  [SerializeField] private VoidEventChannelSO ButtonEvent;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other == null) return;
    ButtonEvent?.RaiseEvent();
    Debug.Log("Push");
  }

}
