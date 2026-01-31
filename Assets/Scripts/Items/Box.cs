using System;
using UnityEngine;

public class Box : MonoBehaviour,IInteraction
{
    [SerializeField] private float offSet;
    public TypeOfInteract InteractType { get; set; }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        InteractType = TypeOfInteract.HoldInteract;
    }
    
    public void Interacted(GameObject game)
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        this.transform.SetParent(game.transform.parent.transform);
        this.transform.position += new Vector3(game.transform.parent.transform.right.x * offSet, 0 , 0);
    }

    public void HoldInteracted(float direction)
    {
        
    }

    public void UnInteracted()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        this.transform.SetParent(null);
    }
}
