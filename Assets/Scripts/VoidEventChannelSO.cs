using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannelSO/VoidEventChannelSO")]
public class VoidEventChannelSO : ScriptableObject
{

    //-----Reentrancy Safe-----
    private bool _isRunning;
    
    //-----Event-----
    public delegate void OnHandler();
    private event OnHandler OnRaised;
    public void RaiseEvent()
    {
        if (_isRunning)
        {
            return;
        }
        try
        {
            if (OnRaised == null)
            {
                return;
            }
            _isRunning = true;
            OnRaised?.Invoke();
        }
        finally
        {
            _isRunning = false;
        }
    }

    public void AddListener(OnHandler listener)
    {
        if (listener == null)
        {
            return;
        }
        OnRaised += listener;
    }

    public void RemoveListener(OnHandler listener)
    {
        if (listener == null)
        {
            return;
        }
        OnRaised -= listener;
    }
    
}
