using System;
using UnityEngine;

public class BoxFalling : MonoBehaviour
{
	private PlayerChangeWorld PCW;
	private void Awake()
	{
		PCW = transform.Find("Player 2").GetComponent<PlayerChangeWorld>();
	}

	private void Start()
	{
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), true);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), false);
	}
	private void Update()
	{

		if (!PCW.isWearingMask)
		{
			
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World1"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), false);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World2"), false);
		}
		else if (PCW.isWearingMask)
		{
			
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World2"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), false);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World1"), false);
		}

	}

}
