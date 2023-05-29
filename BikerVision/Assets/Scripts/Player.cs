using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedM;
    public float speedR;
    public VariableJoystick movimiento;
    public VariableJoystick rotacion;
    Transform jugador;

    void Update()
    {
        jugador = GetComponent<Transform>();
        jugador.position += new Vector3(movimiento.Horizontal*speedM*Time.deltaTime,0,movimiento.Vertical*speedM*Time.deltaTime);
        jugador.Rotate(Vector3.up*speedR*rotacion.Horizontal*Time.deltaTime);
    }
}
