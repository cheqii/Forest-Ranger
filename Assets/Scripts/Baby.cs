using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    private InteractObject _interactObject;

    private void Start()
    {
        _interactObject = GetComponent<InteractObject>();
    }

    void PlayerRescue()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _interactObject.CanInteract)
        {
            
        }
    }
}
