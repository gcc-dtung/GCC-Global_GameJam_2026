using UnityEngine;

public class Parallax2D : MonoBehaviour
{

	float StartPos, Length;
	GameObject cam;
	[SerializeField] float ParallaxEffectSpeed;
	public float distance;

	float movement;
	private void Start()
	{

		StartPos = transform.position.x;
		cam = Camera.main.gameObject;
		Length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	private void Update()
	{
		distance = cam.transform.position.x * ParallaxEffectSpeed;
		movement = cam.transform.position.x * (1 - ParallaxEffectSpeed);

		transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z);

		if (movement > StartPos + Length)
		{
			StartPos += Length;
		}
		else if (movement <= StartPos - Length)
		{
			StartPos -= Length;
		}
	}
}
