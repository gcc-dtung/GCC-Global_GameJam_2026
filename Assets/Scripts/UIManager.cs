using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelOption = new List<GameObject>();
    [SerializeField] private GameObject backButton;
    [SerializeField] private List<int> prevOption = new List<int>();
    [SerializeField] private int currentPanel = 0;
    //[SerializeField] private int nextPanel = 0;

    void Start()
    {
        panelOption[currentPanel].SetActive(true);
        for (int i = 0; i < panelOption.Count; i++)
        {
            if (i == currentPanel)
                continue;
            panelOption[i].SetActive(false);
        }
        backButton.SetActive(false);
    }
    
    public void LoadPanel(int indexOfNextPanel)
    {
        panelOption[currentPanel].SetActive(false);
        prevOption.Add(currentPanel);
        currentPanel = indexOfNextPanel;
        panelOption[indexOfNextPanel].SetActive(true);
        ShowBackButton();
    }

    public void BackPanel()
    {
        if (prevOption.Count == 0)
            return;
        panelOption[prevOption[prevOption.Count - 1]].SetActive(true);
        panelOption[currentPanel].SetActive(false);
        currentPanel =  prevOption[prevOption.Count - 1];
        prevOption.RemoveAt(prevOption.Count - 1);
        ShowBackButton();
    }
    
    private bool CheckMainMenu()
    {
        return currentPanel == 0;
    }

    private void ShowBackButton()
    {
        if (!CheckMainMenu())
        {
            backButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(false);
        }
    }
}
