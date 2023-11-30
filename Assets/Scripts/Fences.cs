using DefaultNamespace;
using UnityEngine;

public class Fences : MonoBehaviour, IInteractableObject
{
    private Rigidbody rb;
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
