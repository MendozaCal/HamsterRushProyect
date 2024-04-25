using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 15;
    float speed;
    public float accelerationTime = 10;
    public float rotationSpeed = 45;
    private float currentSpeed = 0;
    private float acceleration;
    
    //impulso rampa
    public float TimerImpulso = 0;
    public float MaxTimeImpulso = 2;
    public float impulso = 10;
    public bool impulsoVerification = false;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        speed = maxSpeed;
    }

    void Update()
    {
        MoveHamster();
        if(impulsoVerification == true)
        {
            TimerImpulso += Time.deltaTime;
            if (TimerImpulso >= MaxTimeImpulso)
            {
                maxSpeed = speed;
                impulsoVerification = false;
                TimerImpulso = 0;
            }
        }
        
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            maxSpeed *= impulso;
            impulsoVerification = true;
        }
    }
}
