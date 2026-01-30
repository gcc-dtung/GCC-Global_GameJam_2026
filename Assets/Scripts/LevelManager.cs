using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<SceneAsset> levels;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void Load(int index)
    {
        if (index >= levels.Count || levels[index] == null)
        {
            Debug.LogError("LevelManager: Load index out of range or level was null");
            return;
        }
        SceneManager.LoadScene(levels[index].name);
    }

    
}
