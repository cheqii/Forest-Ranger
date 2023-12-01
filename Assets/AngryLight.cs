using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryLight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float blinkingRate;
    public bool isOn;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(ActivateDeactivateRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    IEnumerator ActivateDeactivateRoutine()
    {
        // Activate the Renderer
        light.enabled = true;
        
        // Wait for 1 second
        yield return new WaitForSeconds(blinkingRate);
        
        light.enabled = false;

        
        // Wait for another 1 second
        yield return new WaitForSeconds(blinkingRate);

        // Restart the Coroutine to create a loop
        StartCoroutine(ActivateDeactivateRoutine());
    }
}
