using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
