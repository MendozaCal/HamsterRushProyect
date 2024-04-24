using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 15.0f; 
    public float rotationSpeed = 45.0f; 

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        Vector3 rotation = new Vector3(0.0f, horizontalInput, 0.0f) * rotationSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self);
        transform.Rotate(rotation);
    }
}
