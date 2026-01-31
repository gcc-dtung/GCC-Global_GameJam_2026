using SmallHedge.SoundManager;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
	[SerializeField] Slider SoundSlider;
	[SerializeField] Slider MusicSlider;
	[SerializeField] AudioSource soundManager;
	private void Start()
	{
		soundManager = SoundManager.instance.audioSource;
		MusicSlider.value = 1;
		SoundSlider.value = 1;
	}

	private void Update()
	{
		BackGroundMusic.Instance.audioSource.volume = MusicSlider.value;
		soundManager.volume = SoundSlider.value;
	}
}
