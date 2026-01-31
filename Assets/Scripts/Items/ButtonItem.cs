using System;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
  [SerializeField] private Door _door;
  private Collider2D currentCollider;
  private void OnTriggerEnter2D(Collider2D other)
  {
    _door?.Open();
    Debug.Log("Push");
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    _door?.Close();
  }
}
