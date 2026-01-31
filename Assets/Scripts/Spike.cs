using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			collision.gameObject.GetComponent<PlayerChangeWorld>().PlayEffect();
		}
	}
}
