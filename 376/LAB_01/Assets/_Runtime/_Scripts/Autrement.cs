using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autrement : MonoBehaviour
{
    public float speed = 5f; // Speed of the object movement
    public float rotationSpeed = 720f; // Speed of rotation (degrees per second)

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        // Check if the "W" key is being pressed
        if (Input.GetKey("w"))
        {
            movementDirection += Vector3.forward;
        }
        if (Input.GetKey("a"))
        {
            movementDirection += Vector3.left;
        }
        if (Input.GetKey("s"))
        {
            movementDirection += Vector3.back;
        }
        if (Input.GetKey("d"))
        {
            movementDirection += Vector3.right;
        }

        // Normalize the movement direction to ensure consistent movement speed
        if (movementDirection != Vector3.zero)
        {
            movementDirection.Normalize();
            // Move the object in the direction calculated
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

            // Smoothly rotate the object towards the direction of movement
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}