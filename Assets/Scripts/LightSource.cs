using UnityEngine;
using UnityEngine.Events;

public class LightSource : MonoBehaviour
{
	public int maxReflections = 5;
	public float maxDistance = 50f;
	public LayerMask reflectLayer;
	public LayerMask blockLayer;
	public LayerMask sensorLayer;
	public UnityEvent OnSensorReceive;
	public UnityEvent OnSensorExit;
	
	LineRenderer lr;

	bool isHittingSensor; // state memory

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
		bool hitSensorThisFrame = false;

		lr.positionCount = 1;
		lr.SetPosition(0, transform.position);

		Vector2 position = transform.position;
		Vector2 direction = transform.right;

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

			lr.positionCount++;
			lr.SetPosition(lr.positionCount - 1, hit.point);

			int hitLayerMask = 1 << hit.collider.gameObject.layer;

			if ((hitLayerMask & sensorLayer) != 0)
			{
				hitSensorThisFrame = true;
				break;
			}

			if ((hitLayerMask & reflectLayer) != 0)
			{
				direction = Vector2.Reflect(direction, hit.normal);
				position = hit.point + direction * 0.01f;
				continue;
			}

			// wall
			break;
		}

		// --- SENSOR STATE CHANGES ---
		if (hitSensorThisFrame && !isHittingSensor)
		{
			OnSensorReceive.Invoke(); // ENTER
		}
		else if (!hitSensorThisFrame && isHittingSensor)
		{
			OnSensorExit.Invoke(); // EXIT
		}

		isHittingSensor = hitSensorThisFrame;
	}
	public void Test()
	{
		Debug.Log("hit");
	}
	public void test2()
	{
		Debug.Log("NotHit");
		
	}
}
