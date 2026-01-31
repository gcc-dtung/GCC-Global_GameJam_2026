using UnityEngine;
using UnityEngine.SceneManagement;

public class TestWin : MonoBehaviour
{
    public void WinState()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("LevelUnlock", PlayerPrefs.GetInt("LevelUnlock", 1) + 1);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(0);
    }
}
