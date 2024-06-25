using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TextMeshPro Text;
    [Header("-----Move-----")]
    public float maxSpeed = 20;
    public float accelerationTime = 10;
    public float rotationSpeed = 90;
    public float incialSpeed;
    public float Speed;
    public float currentSpeed = 0;
    public float gravity = 3;
    Rigidbody rb;
    public bool isMove = true;
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
    public bool isNitro = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        incialSpeed = maxSpeed;
        Speed = maxSpeed;
        NitroSlider.maxValue = maxNitro;
    }
    void FixedUpdate()
    {
        maxSpeed = Mathf.Min(maxSpeed, incialSpeed);
        maxNitro = Mathf.Clamp(maxNitro, 0, 100);
        NitroSlider.value = maxNitro;
        if (isNitro == true)
        {
            Nitro();
        }
        if (isMove == true)
        {
            MoveHamster();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void MoveHamster()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        bool isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        if (isMoving)
        {
            currentSpeed += accelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }
        else
        {
            currentSpeed -= accelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        Vector3 movement = new Vector3(0, 0, verticalInput * currentSpeed);
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
            maxSpeed = incialSpeed;
        }
    }
    public void BustRampa()
    {
        maxSpeed = incialSpeed;
        maxSpeed += impulso;
        TimerImpulso += Time.deltaTime;
        if (TimerImpulso >= MaxTimeImpulso)
        {
            maxSpeed = incialSpeed;
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