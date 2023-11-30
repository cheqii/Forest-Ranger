using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("JumpScare");
    }
}
