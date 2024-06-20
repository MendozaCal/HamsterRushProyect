using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDirection : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio o un punto de referencia en la pista
    private Vector3 lastPosition;
    private bool isMovingForward = true;

    void Start()
    {
    }
    void Update()
    {
        lastPosition = transform.position;

        CheckMovementDirection();
        // Aquí iría el código para mover el jugador.
    }
    void CheckMovementDirection()
    {
        // Calcula la dirección hacia adelante basándose en el punto de referencia
        Vector3 forwardDirection = (transform.position - startPoint.position).normalized;
        // Calcula la dirección de movimiento actual
        Vector3 currentDirection = (transform.position - lastPosition).normalized;
        // Comprueba si el jugador se está moviendo hacia adelante
        isMovingForward = Vector3.Dot(forwardDirection, currentDirection) > 0;
        if (!isMovingForward)
        {
            // Aquí puedes implementar lo que quieres que suceda si el jugador está retrocediendo
            // Por ejemplo, frenar al jugador, mostrar un mensaje, etc.
            Debug.Log("¡No puedes retroceder!");
        }
        lastPosition = transform.position;
    }
}
