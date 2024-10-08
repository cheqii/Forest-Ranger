using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObject : MonoBehaviour
{
    public string triggerTagName;
    // public Nf_GameEvent triggerEvent;
    public UnityEvent OnTrigger = new UnityEvent();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggerTagName)
        {
            if (triggerTagName == "CameraArea")
            {
                var _camera = other.gameObject.GetComponent<Capture>();
                _camera.CameraCapture();
                OnTrigger.Invoke();
                Destroy(this.gameObject);
            }
            
            OnTrigger.Invoke();
            Destroy(this.gameObject);
        }
    }
}
