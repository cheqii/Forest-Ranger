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

    [SerializeField] private AudioSource mysteriousSound;

    private StrangeObject strangeObj;
    private Rigidbody currentCapturingRb;
    private Collider currentCapturingCol;
    // Update is called once per frame
    void Update()
    {
        CameraCapture();
    }

    private void CameraCapture()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && canCapture ||
            canCapture && Input.GetKeyDown(KeyCode.Backspace))
        {
            if(strangeObj.HaveFound) return;

            currentCapturingCol.isTrigger = false;
            cameraCaptureEvent.Raise();
            strangeObj.HaveFound = true;
            currentCapturingRb.isKinematic = false;
            StartCoroutine(CameraLightDelay());
        }
    }

    public void SetCameraLight(float _value)
    {
        camLight.intensity = _value;
    }

    IEnumerator CameraLightDelay()
    {
        yield return new WaitForSeconds(camLightDelay);
        mysteriousSound.Play();
        SetCameraLight(0);
        ResetCamera();
    }

    private void ResetCamera()
    {
        strangeObj = null;
        currentCapturingRb = null;
        currentCapturingCol = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StrangeObject"))
        {
            canCapture = true;
            strangeObj = other.GetComponent<StrangeObject>();
            currentCapturingRb = other.GetComponent<Rigidbody>();
            currentCapturingCol = other.GetComponent<Collider>();
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
