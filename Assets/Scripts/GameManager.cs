using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _ins;
    public static GameManager instance => _ins;
    void Awake()
    {
        if (_ins == null) { _ins = this.GetComponent<GameManager>(); return;}
        if(_ins.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) Destroy(this.gameObject);
    }
    public bool IsGameDone = false;
    public void StopGame()
    {
        Time.timeScale = 0f;
        IsGameDone = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        IsGameDone = false;
    }
}
