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
    //float acceleration;
    Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
        //acceleration = maxSpeed / accelerationTime;
        speed = maxSpeed;
        NitroSlider.maxValue = maxNitro;
    }

    void FixedUpdate()
    {
        maxSpeed = Mathf.Min(maxSpeed, 20);
        maxNitro = Mathf.Min(maxNitro, 100);
        maxNitro = Mathf.Max(maxNitro, 0);
        MoveHamster();
        Nitro();
    }
    public void MoveHamster()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * maxSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);

        rb.MovePosition(transform.position + transform.TransformDirection(movement));
        rb.MoveRotation(rb.rotation * rotation);
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
