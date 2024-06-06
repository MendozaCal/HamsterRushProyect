using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("-----Move-----")]
    public float maxSpeed = 15;
    public float accelerationTime = 10;
    public float rotationSpeed = 45;
    float speed;
    public float currentSpeed = 0;
    public float gravity;
    Rigidbody rb;

    [Header("-----Nitro-----")]
    public float maxNitro = 100;
    public float nitroPower = 15;
    public float nitroItem = 25;
    public Slider NitroSlider;
    
    [Header("-----Impulso Rampa-----")]
    public float MaxTimeImpulso = 2;
    public float impulso = 15;
    float TimerImpulso = 0;
    public bool impulsoVerification = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = maxSpeed;
        NitroSlider.maxValue = maxNitro;
    }

    void FixedUpdate()
    {
        maxSpeed = Mathf.Min(maxSpeed, speed);
        maxNitro = Mathf.Clamp(maxNitro, 0, 100);
        NitroSlider.value = maxNitro;
        Nitro();
        MoveHamster();
    }
    public void MoveHamster()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, 0, verticalInput * maxSpeed) ;
        movement.y = rb.velocity.y + (Physics.gravity.y * gravity * Time.deltaTime); ;

        rb.velocity = transform.TransformDirection(movement);

        Quaternion rotation = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }
    public void Nitro()
    {
        if (Input.GetKey(KeyCode.LeftShift) && maxNitro > 0)
        {
            maxNitro -= Time.deltaTime * 10;
            maxSpeed += nitroPower;
        }
        else if(impulsoVerification == true)
        {
            BustRampa();
        }
        else
        {
            maxSpeed = speed;
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
        if (other.gameObject.CompareTag("Nitro"))
        {
            maxNitro += nitroItem;
        }   
    }
}
