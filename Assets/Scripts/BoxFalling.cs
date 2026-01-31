using System;
using UnityEngine;

public class BoxFalling : MonoBehaviour
{
	private PlayerChangeWorld PCW;
	bool isWearingMask;

	private void Start()
	{
		PCW = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChangeWorld>();
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), true);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), false);
	}
	private void Update()
	{
		isWearingMask = PCW.isWearingMask;
		if (PCW.isWearingMask)
		{
			
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World1"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), false);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World2"), false);
		}
		else if (!PCW.isWearingMask)
		{
			
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground2"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World2"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Ground1"), false);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("World1"), false);
		}

	}

}
