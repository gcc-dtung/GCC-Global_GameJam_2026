using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private SceneEnum level;
    public void LoadScene()
    {
        SceneManager.LoadScene((int)level);
    }
}
