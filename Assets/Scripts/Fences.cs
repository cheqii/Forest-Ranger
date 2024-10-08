using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Fences : MonoBehaviour, IInteractableObject
{
    private Rigidbody rb;

    [SerializeField] private Nf_GameEvent doorEvent;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Interactable()
    {
        rb.isKinematic = false;
        rb.AddForce(0f, 0f, 2f, ForceMode.Impulse);
        
        doorEvent.Raise();
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashLight"))
        {
            rb.isKinematic = false;
            rb.AddForce(0f, 0f, 2f, ForceMode.Impulse);
            
            doorEvent.Raise();
            Destroy(gameObject, 2f);
        }
    }
}
