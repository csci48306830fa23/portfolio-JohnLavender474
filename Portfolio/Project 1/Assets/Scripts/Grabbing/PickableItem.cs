using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour
{

    private Rigidbody rb;
    public Rigidbody Rb => rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

}
