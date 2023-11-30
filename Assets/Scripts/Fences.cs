using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Oculus.Interaction;
using UnityEngine;

public class Fences : MonoBehaviour, IInteractableObject
{
    private Rigidbody rb;
    public bool isbroken;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Interactable()
    {
        rb.isKinematic = false;
        rb.AddForce(0f, 0f, 2f, ForceMode.Impulse);
        
        Destroy(gameObject, 3f);
    }
}
