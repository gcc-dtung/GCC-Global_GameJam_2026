using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float maxCountTimer = 0.5f;
    [SerializeField] private float countTimer;

    public void SetUp()
    {
        countTimer = maxCountTimer;
    }
    
    public void Rotate(float multiphyler)
    {
        countTimer -= Time.deltaTime;
        if (multiphyler == 0) countTimer = maxCountTimer;
        if(countTimer >= 0f) transform.Rotate(new Vector3(0,0,-1 * multiphyler));
        else transform.Rotate(new Vector3(0,0,-1.5f*multiphyler));
    }
    
}
