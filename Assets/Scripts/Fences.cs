using DefaultNamespace;
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
}
