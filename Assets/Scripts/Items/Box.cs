using System;
using UnityEngine;

public class Box : MonoBehaviour,IInteraction
{
    public TypeOfInteract InteractType { get; set; }
    private FixedJoint2D _joint2D;
    private Rigidbody2D rb;
    private string _typeOfInteract;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        _joint2D = this.GetComponent<FixedJoint2D>();
        InteractType = TypeOfInteract.HoldInteract;
    }

    private void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX
                         | RigidbodyConstraints2D.FreezeRotation;
    }


    public void Interacted(GameObject game)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _joint2D.enabled = true;
        _joint2D.connectedBody = game.GetComponent<Rigidbody2D>();
    }

    public void UnInteracted()
    {
        _joint2D.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX
                         | RigidbodyConstraints2D.FreezeRotation;
    }
}
