using UnityEngine;

public class LightDetector : MonoBehaviour
{
    // Put this script to anything you want to detect light from "Flashlight"
    // Set "Is Trigger" to this object collider
    [SerializeField] private GameObject miniJumpScareObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashLight"))
        {
            if (miniJumpScareObject != null)
            {
                miniJumpScareObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}