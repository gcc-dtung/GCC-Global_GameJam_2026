using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private SceneEnum level;
    public void LoadScene()
    {
        LevelManager.Instance.Load((int)level);
    }
}
