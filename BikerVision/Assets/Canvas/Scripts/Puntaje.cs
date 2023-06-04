using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public Juego control;
    public TMP_Text puntaje;

    void Update(){
        puntaje.text = "Puntaje: "+control.puntaje;
    }
}
