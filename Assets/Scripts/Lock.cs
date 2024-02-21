using DefaultNamespace;
using UnityEngine;

public class Lock : MonoBehaviour, IInteractableObject
{
    
    public void Interactable()
    {
        Debug.Log($"Destroy {gameObject.name}!");
        Destroy(gameObject);
    }
}
