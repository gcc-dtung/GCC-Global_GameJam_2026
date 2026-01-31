using System;
using UnityEngine;

public class TestWinLevel : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO winEventChannel;

    private void Update()
    {
        if (transform.position.y >= 3)
        {
            winEventChannel.RaiseEvent();
        }
    }
}
