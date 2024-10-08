using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeObject : MonoBehaviour
{
    [SerializeField] private bool haveFound;
    public bool HaveFound
    {
        get => haveFound;
        set => haveFound = value;
    }
    
    
}
