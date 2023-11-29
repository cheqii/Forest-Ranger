using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement

    void Update()
    {
        // Get input from the player
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
