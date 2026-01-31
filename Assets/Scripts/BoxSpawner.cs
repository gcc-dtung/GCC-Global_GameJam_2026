using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private GameObject spike;
    [SerializeField] private Transform spikePosition;
    [SerializeField] private VoidEventChannelSO BoxSpawnChannel;
    private int amount = 0;
    private bool isDone = false;
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
        if (amount > 2 && !isDone)
        {
            Instantiate(spike,this.spikePosition.position,Quaternion.identity);
            isDone = true;
            return;
        }
     Instantiate(prefabs,this.transform.position,Quaternion.identity);
     amount++;
    }
    
    
}
