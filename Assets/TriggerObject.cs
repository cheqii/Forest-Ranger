using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObject : MonoBehaviour
{
    public string triggerTagName;
    
    public float destroyDelay;
    public UnityEvent OnTrigger = new UnityEvent();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggerTagName)
        {
            if (triggerTagName == "CameraArea")
            {
                var _camera = other.gameObject.GetComponent<Capture>();
                if (_camera.StrangeObj.HaveFound)
                {
                    StartCoroutine(CameraDelay());
                }
            }
            
            OnTrigger.Invoke();
            Destroy(this.gameObject, destroyDelay);
        }
    }

    IEnumerator CameraDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        OnTrigger.Invoke();
        Destroy(this.gameObject, 0.5f);
    }
}
