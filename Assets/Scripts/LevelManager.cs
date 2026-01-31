using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new List<Button>();
    private int currentLevel = 0;
    protected void Awake()
    {
        //PlayerPrefs.DeleteAll();
        int unlockLevel = PlayerPrefs.GetInt("LevelUnlock", 1);
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockLevel; i++)
        {
            buttons[i].interactable = true;
        }
            
    }
    

    public void Load(int index)
    {
        if (index > 10)
            return;
        currentLevel = index;
        SceneManager.LoadScene(index);
    }
    
    public void WinLevel()
    {
        // if (currentLevel < 10 && !_unlockedLevels[currentLevel + 1])
        // {
        //     _unlockedLevels[currentLevel + 1] = true;
        // }
        Load(0);
        //CheckLock();
    }

    
    
}
