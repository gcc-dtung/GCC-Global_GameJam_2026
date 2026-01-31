using SmallHedge.SoundManager;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
	public void MoveSFX()
	{
		SoundManager.PlaySound(SoundType.Run);
	}
	public void Jump()
	{
		SoundManager.PlaySound(SoundType.Jump);
	}
	public void Land()
	{
		SoundManager.PlaySound(SoundType.Land);
	}
}
