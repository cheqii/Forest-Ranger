using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    [SerializeField] private bool canCapture;

    [SerializeField] private Nf_GameEvent cameraCaptureEvent;

    [SerializeField] private Light camLight;

    [SerializeField] private float camLightDelay = 0.2f;

    private Rigidbody currentCapturingRb;
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && canCapture ||
            canCapture && Input.GetKeyDown(KeyCode.Backspace))
        {
            CameraCapture();
        }
    }

    public void CameraCapture()
    {
        cameraCaptureEvent.Raise();
        currentCapturingRb.isKinematic = false;
        StartCoroutine(CameraLightDelay());
    }

    public void SetCameraLight(float _value)
    {
        camLight.intensity = _value;
    }

    IEnumerator CameraLightDelay()
    {
        yield return new WaitForSeconds(camLightDelay);
        SetCameraLight(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StrangeObject"))
        {
            canCapture = true;
            currentCapturingRb = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StrangeObject"))
        {
            canCapture = false;
        }
    }
}
