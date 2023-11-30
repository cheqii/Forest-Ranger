using System.Collections;
using UnityEngine;

public class LightBlinker : MonoBehaviour
{
    // Put this script to your "Flashlight" that have "Light" Component
    [SerializeField] private Light targetLight;
    [SerializeField] private float blinkDuration = 3f;
    [SerializeField] private float blinkFrequency = 0.1f;

    private void Start()
    {
        targetLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartBlink();
        }
    }

    public void StartBlink()
    {
        StartCoroutine(BlinkLight());
    }

    IEnumerator BlinkLight()
    {
        float timeElapsed = 0f;

        while (timeElapsed < blinkDuration)
        {
            targetLight.enabled = !targetLight.enabled;

            yield return new WaitForSeconds(blinkFrequency);
            timeElapsed += blinkFrequency;
        }

        targetLight.enabled = true;
    }
}