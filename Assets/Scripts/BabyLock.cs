using System.Collections.Generic;
using UnityEngine;

public class BabyLock : MonoBehaviour
{
    [SerializeField] private List<GameObject> _locks;
    [SerializeField] private Nf_GameEvent escapeEvent;
    
    private void Update()
    {
        CheckLock();
    }

    void CheckLock()
    {
        if(_locks[0].gameObject == null && _locks[1].gameObject == null)
        {
            escapeEvent.Raise();
            Destroy(gameObject);
        }
    }
}
