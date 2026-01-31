using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
   private BoxCollider2D _collider2D;
   [SerializeField] private float MaxHeight;
   [SerializeField] private float MinHeight;
   private void Awake()
   {
      _collider2D = this.GetComponent<BoxCollider2D>();
   }
   
   public void Open()
   {
      Tween.PositionY(transform, endValue: MaxHeight, duration: 1, ease: Ease.InOutSine);
   }

   public void Close()
   {
      Tween.PositionY(transform, endValue: MinHeight, duration: 1, ease: Ease.InOutSine);
   }
}
