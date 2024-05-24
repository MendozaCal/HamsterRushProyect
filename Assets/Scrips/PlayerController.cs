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
    bool nitroItemVerification = false;
    public Slider NitroSlider;
    
    [Header("-----Impulso Rampa-----")]
    public float MaxTimeImpulso = 2;
    public float impulso = 15;
    float TimerImpulso = 0;
    public bool impulsoVerification = false;

    [Header("-----Cont Vueltas-----")]
    public TextMeshPro Contador;
    int laps = 1;
    public int MaxLaps = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = maxSpeed;
        NitroSlider.maxValue = maxNitro;
    }

    void FixedUpdate()
    {
        maxSpeed = Mathf.Min(maxSpeed, speed);
        maxNitro = Mathf.Min(maxNitro, 100);
        maxNitro = Mathf.Max(maxNitro, 0);
        Nitro();
        MoveHamster();
        FinalRase();
    }
    public void MoveHamster()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * maxSpeed;
        movement.y = rb.velocity.y + (Physics.gravity.y * gravity * Time.deltaTime); ;

        rb.velocity = transform.TransformDirection(movement);

        Quaternion rotation = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }
    public void Nitro()
    {
        NitroSlider.value = maxNitro;
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
        if (other.gameObject.CompareTag("Meta"))
        {
            laps++;
            Contador.text = $"Lap {laps}/{MaxLaps}";
        }
    }
    void FinalRase()
    {
        if (laps > MaxLaps)
        {
            SceneManager.LoadScene(0);
        }
    }
}
