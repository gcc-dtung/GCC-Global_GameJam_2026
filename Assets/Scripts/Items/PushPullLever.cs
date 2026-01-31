using System;
using UnityEngine;

public class PushPullLever : MonoBehaviour,IInteraction
{
	public TypeOfInteract InteractType { get; set; }
	[SerializeField] private VoidEventChannelSO pushPullLeverEvent;
	[SerializeField] Door _door;
	private Animator _animator;
	private bool logic = true;
	public void Awake()
	{
		InteractType = TypeOfInteract.PressInteract;
		_animator = this.GetComponent<Animator>();
	}

	public void Interacted(GameObject game)
	{
		Debug.Log("interacted");
		pushPullLeverEvent?.RaiseEvent();

		if (logic == true)
		{
		_animator.SetTrigger("Push");
		if(_door!= null) _door.Open();
		}
		else 
		{
			_animator.SetTrigger("Pull");
			_door.Close();
		}

		logic = !logic;
	}

	public void HoldInteracted(float direction)
	{
		
	}

	public void UnInteracted()
	{
	   
	}
}
