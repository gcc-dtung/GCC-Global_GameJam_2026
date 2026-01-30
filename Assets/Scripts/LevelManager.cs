using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<SceneAsset> levels;
    private bool[] _unlockedLevels = new bool[11];
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _unlockedLevels[0] = true;
        _unlockedLevels[1] = true;
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
