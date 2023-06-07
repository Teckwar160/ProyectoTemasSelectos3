using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Variable de control de juego
    public Juego control;

    // Variable del texto del canvas
    public TMP_Text puntaje;

    void Update(){
        // Actualizamos el texto del canvas en base al puntaje obtenido en el control del juego
        puntaje.text = "Puntaje: "+control.puntaje;
    }
}
