using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    // Variable de control de juego
    public Juego control;

    // Detecta las colisiones con las cajas
    public void OnTriggerEnter(Collider other){
        // Destruye la caja en cuestión
        control.destruirCajas(other.gameObject);

        // Decrementamos el puntaje
        control.puntaje--;
    }
}
