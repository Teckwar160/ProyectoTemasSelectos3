using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{

    public Juego control;

    public void OnTriggerEnter(Collider other){
        control.destruirCajas(other.gameObject);
        control.puntaje--;
    }
}
