using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    public void WenPressThisButton()
    {
        settingPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    
    
}
