using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
	private BoxCollider2D _collider2D;
	[SerializeField] private float duration;
	[SerializeField] private float MaxHeight;
	[SerializeField] private float MinHeight;
	private Tween alo;
	private void Awake()
	{
		_collider2D = this.GetComponent<BoxCollider2D>();
	}
	
	public void Open()
	{
		if (alo.isAlive) return;
		alo = Tween.PositionY(transform, endValue: MaxHeight+transform.position.y, duration: duration, ease: Ease.InOutSine);
	}

	public void Close()
	{
		if (alo.isAlive) return;
		alo = Tween.PositionY(transform, endValue: MinHeight+transform.position.y, duration: duration, ease: Ease.InOutSine);
	}

	private void OnDisable()
	{
		if (alo.isAlive)
		{
			alo.Stop();
		}
	}
}
