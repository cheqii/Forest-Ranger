using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public Camera mainCamera; // Reference to the main camera

    void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;

        // Check if a camera was found
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene!");
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // Get input from the player
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            // Calculate the movement direction relative to the camera
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0f; // Ensure no vertical movement
            cameraRight.y = 0f; // Ensure no vertical movement
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 movement = cameraForward * verticalMovement + cameraRight * horizontalMovement;

            // Move the player
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
