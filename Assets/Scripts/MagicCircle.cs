using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public int count = 0;
    [SerializeField] private int totemMaxCount = 4;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Totem"))
        {
            count++;
            Destroy(collision.gameObject);
        }

        if (count >= totemMaxCount)
        {
            Full();
        }
    }

    private void Full()
    {
        Destroy(this.gameObject);
    }
}
