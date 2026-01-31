using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
	public static BackGroundMusic Instance;
	public AudioSource audioSource;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		audioSource = GetComponent<AudioSource>();
	}
}
