using System.Collections.Generic;
using UnityEngine;

public class BabyLock : MonoBehaviour
{
    [SerializeField] private List<GameObject> _locks;

    private void Update()
    {
        CheckLock();
    }

    void CheckLock()
    {
        
        // if (_locks[0].gameObject == null && _locks[1].gameObject == null
        //     && _locks[2].gameObject == null && _locks[3].gameObject == null)
        // {
        //     Destroy(gameObject);
        // }
        
        if(_locks[0].gameObject == null && _locks[1].gameObject == null)
        {
            Destroy(gameObject);
        }
    }
}
