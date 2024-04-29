using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("-----Move-----")]
    public float maxSpeed = 15;
    public float accelerationTime = 10;
    public float rotationSpeed = 45;
    float speed;
    public float currentSpeed = 0;
    float acceleration;

    [Header("-----Nitro-----")]
    public float maxNitro = 100;
    public float nitroPower = 10;
    public float nitroItem = 25;
    bool nitroItemVerification = false;
    public Slider NitroSlider;
    
    [Header("-----Impulso Rampa-----")]
    public float MaxTimeImpulso = 2;
    public float impulso = 10;
    float TimerImpulso = 0;
    bool impulsoVerification = false;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        speed = maxSpeed;
        NitroSlider.maxValue = maxNitro;
    }

    void FixedUpdate()
    {
        maxSpeed = Mathf.Min(maxSpeed, 50);
        maxNitro = Mathf.Min(maxNitro, 100);
        maxNitro = Mathf.Max(maxNitro, 0);
        MoveHamster();
        Nitro();
    }
    public void MoveHamster()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0, maxSpeed); //Aceleraci�n Progresiba de 0 a maxSpeed // Clamp = parametros

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * currentSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(0, horizontalInput, 0) * rotationSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self); //Encargado de movimiento //Space.Self = para q se quede mirando a donde giraste
        transform.Rotate(rotation.normalized);
    }
    public void Nitro()
    {
        if (Input.GetKey(KeyCode.LeftShift) && maxNitro > 0)
        {
            maxNitro -= Time.deltaTime * 10;
            maxSpeed += nitroPower;
            NitroSlider.value = maxNitro;
        }
        else if(impulsoVerification == true)
        {
            BustRampa();
        }
        else
        {
            maxSpeed = speed;
        }
        if(nitroItemVerification == true)
        {
            maxNitro += nitroItem;
            NitroSlider.value = maxNitro;
            nitroItemVerification = false;
        }
    }
    public void BustRampa()
    {
        maxSpeed = speed;
        maxSpeed += impulso;
        TimerImpulso += Time.deltaTime;
        if (TimerImpulso >= MaxTimeImpulso)
        {
            maxSpeed = speed;
            impulsoVerification = false;
            TimerImpulso = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            impulsoVerification = true;
        }
        if (other.gameObject.CompareTag("Nitro"))
        {
            nitroItemVerification = true;
        }
    }
}
