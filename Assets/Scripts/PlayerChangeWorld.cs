using PrimeTween;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeWorld : MonoBehaviour
{
	[SerializeField] GameObject mask;
	public bool isWearingMask = false;
	PlayerMovement PM;
	bool overlap;
	[SerializeField] LayerMask NoMask;
	InputAction WearMask;
	[SerializeField] SpriteRenderer TransitionSR;
	private void Awake()
	{
		WearMask = InputSystem.actions.FindAction("Mask");
		PM = GetComponent<PlayerMovement>();
	}
	private void Start()
	{
		PM.GroundLayer = LayerMask.GetMask("Ground1");
		TransitionSR.color = new Color(0.000f, 0.000f, 0.000f, 0.000f);
		mask.SetActive(false);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground2"), true);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground1"), false);
	}
	private void Update()
	{
		overlap = Physics2D.OverlapBox(transform.position, new Vector2(0.9f, 1.9f), 0f, NoMask);
		if (WearMask.WasPressedThisFrame() && !isWearingMask && !overlap)
		{
			PlayEffect();
			mask.SetActive(true);
			isWearingMask = true;
			PM.GroundLayer = LayerMask.GetMask("Ground2");
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground1"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground2"), false);
		}
		else if (WearMask.WasPressedThisFrame() && isWearingMask && !overlap)
		{
			PlayEffect();
			mask.SetActive(false);
			isWearingMask = false;
			PM.GroundLayer = LayerMask.GetMask("Ground1");
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground2"), true);
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Both"), LayerMask.NameToLayer("Ground1"), false);
		}
		else if (WearMask.WasPressedThisFrame() && overlap)
		{
			Debug.Log("Cant here");
		}
	}
	public void PlayEffect()
	{
		Tween.Custom(Color.black,new Color(0.000f, 0.000f, 0.000f, 0.000f),duration:0.5f,onValueChange: newVal => TransitionSR.color = newVal);
	}
}
