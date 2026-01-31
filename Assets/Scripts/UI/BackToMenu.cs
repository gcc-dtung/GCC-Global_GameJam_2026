using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
