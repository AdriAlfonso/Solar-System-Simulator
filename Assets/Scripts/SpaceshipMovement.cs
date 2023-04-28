using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 50.0f; // Speed of the object's movement
    public float sensitivity = 2.0f; // Mouse sensitivity
    public float maxInclination = 80.0f; // Maximum vertical rotation angle
    public float horizontalRotation = 0.0f; // Current horizontal rotation angle
    public float verticalRotation = 0.0f; // Current vertical rotation angle

    void Update () {
        // Get mouse rotation input
        horizontalRotation += Input.GetAxis("Mouse X") * sensitivity;
        verticalRotation += -Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxInclination, maxInclination);
        
        // Rotate the object
        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0.0f);

        // Get keyboard movement input
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float ascensionMovement = 0.0f;

        if (Input.GetKey(KeyCode.Space)) {
            ascensionMovement = 1.0f;
        } else if (Input.GetKey(KeyCode.LeftShift)) {
            ascensionMovement = -1.0f;
        }

        // Move the object
        Vector3 movement = new Vector3(horizontalMovement, ascensionMovement, verticalMovement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
