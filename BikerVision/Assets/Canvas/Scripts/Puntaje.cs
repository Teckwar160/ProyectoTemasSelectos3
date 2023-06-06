using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Variable de control de juego
    public Juego control;

    // Variable del texto del canva
    public TMP_Text puntaje;

    void Update(){
        // Actualziamos el texto del canva en base al obtenido en el control del juego
        puntaje.text = "Puntaje: "+control.puntaje;
    }
}
