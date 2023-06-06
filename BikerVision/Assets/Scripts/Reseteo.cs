using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseteo : MonoBehaviour
{
    // Variables publicas necesarias para el reseteo
    public Transform target;
    public Transform player;
    public Vector3 posicion;

    // Variable temporal
    Transform targetT;

    public void reinicio()
    {
        // Obtenemos el componente Transform del target
        targetT = target.GetComponent<Transform>();

        // Definimos la posición del modelo en base a la posición del target
        player.position = new Vector3(targetT.position.x+posicion.x,targetT.position.y+posicion.y,
                                      targetT.position.z+posicion.z);
    }
}
