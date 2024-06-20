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
        // Aqu� ir�a el c�digo para mover el jugador.
    }
    void CheckMovementDirection()
    {
        // Calcula la direcci�n hacia adelante bas�ndose en el punto de referencia
        Vector3 forwardDirection = (transform.position - startPoint.position).normalized;
        // Calcula la direcci�n de movimiento actual
        Vector3 currentDirection = (transform.position - lastPosition).normalized;
        // Comprueba si el jugador se est� moviendo hacia adelante
        isMovingForward = Vector3.Dot(forwardDirection, currentDirection) > 0;
        if (!isMovingForward)
        {
            // Aqu� puedes implementar lo que quieres que suceda si el jugador est� retrocediendo
            // Por ejemplo, frenar al jugador, mostrar un mensaje, etc.
            Debug.Log("�No puedes retroceder!");
        }
        lastPosition = transform.position;
    }
}
