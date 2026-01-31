using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO winChannel;

    private void OnEnable()
    {
        winChannel.AddListener(SaySth);
    }

    private void OnDisable()
    {
        winChannel.RemoveListener(SaySth);
    }

    void SaySth()
    {
        Debug.Log("Win");
    }
}
