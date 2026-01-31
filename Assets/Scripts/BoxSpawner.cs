using System;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private VoidEventChannelSO BoxSpawnChannel;

    private void OnEnable()
    {
        BoxSpawnChannel.AddListener(SpawnObject);
    }

    private void OnDisable()
    {
        BoxSpawnChannel.RemoveListener(SpawnObject);
    }

    public void SpawnObject()
    {
     Instantiate(prefabs,this.transform.position,Quaternion.identity);
    }
}
