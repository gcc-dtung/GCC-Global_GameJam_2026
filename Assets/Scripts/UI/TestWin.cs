using UnityEngine;
using UnityEngine.SceneManagement;

public class TestWin : MonoBehaviour
{
    private void WinState()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("LevelUnlock", PlayerPrefs.GetInt("LevelUnlock", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        WinState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackMenu()
    {
        WinState();
        SceneManager.LoadScene(0);
    }
}
