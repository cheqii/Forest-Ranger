using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            other.GetComponent<Ghost>().RunAway();
        }
    }
}
