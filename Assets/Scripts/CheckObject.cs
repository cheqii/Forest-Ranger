using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    public void CheckIsDoor()
    {
        if (gameObject.name == "Door")
        {
            Destroy(gameObject);
        }
    }
}
