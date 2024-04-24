using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float maxSpeed = 15f;
    public float accelerationTime = 10f;

    private float currentSpeed = 0f;
    private float acceleration;

    public float rotationSpeed;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    void Update()
    {
        MoveHamster();
    }
    public void MoveHamster()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0, maxSpeed); //Aceleración Progresiba de 0 a maxSpeed // Clamp = parametros

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * currentSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(0, horizontalInput, 0) * rotationSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self); //Encargado de movimiento //Space.Self = para q se quede mirando a donde giraste
        transform.Rotate(rotation.normalized);
    }
    public void Nitro()
    {

    }
}
