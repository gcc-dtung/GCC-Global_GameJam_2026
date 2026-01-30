using UnityEngine;
using UnityEngine.Events;

public class LightSource : MonoBehaviour
{
	public int maxReflections = 5;
	public float maxDistance = 50f;
	public LayerMask reflectLayer;
	public LayerMask blockLayer;
	public LayerMask sensorLayer;
	public UnityEvent OnSensorRecieve;

	LineRenderer lr;

	void Awake()
	{
		lr = GetComponent<LineRenderer>();
		lr.positionCount = 1;
		lr.useWorldSpace = true;
	}

	void Update()
	{
		CastLight();
	}

	void CastLight()
	{
		lr.positionCount = 1;
		lr.SetPosition(0, transform.position);

		Vector2 position = transform.position;
		Vector2 direction = transform.right; // forward direction

		for (int i = 0; i < maxReflections; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(
				position,
				direction,
				maxDistance,
				reflectLayer | blockLayer | sensorLayer
			);

			if (!hit)
			{
				lr.positionCount++;
				lr.SetPosition(lr.positionCount - 1, position + direction * maxDistance);
				break;
			}

			// draw hit point
			lr.positionCount++;
			lr.SetPosition(lr.positionCount - 1, hit.point);

			// hit mirror → reflect
			if (((1 << hit.collider.gameObject.layer) & reflectLayer) != 0)
			{
				direction = Vector2.Reflect(direction, hit.normal);
				position = hit.point + direction * 0.01f; // offset to avoid self-hit
			}
			else if (((1 << hit.collider.gameObject.layer) & sensorLayer) != 0)
			{
				OnSensorRecieve.Invoke();
				break;
			}
			else
			{
				// hit wall → stop
				break;
			}
		}
	}
	public void test()
	{
		Debug.Log("Nice");
	}
}
