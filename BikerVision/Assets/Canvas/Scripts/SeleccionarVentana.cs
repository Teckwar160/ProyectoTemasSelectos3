using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeleccionarVentana : MonoBehaviour
{

    // Fichas técnicas de las motocicletas
    public GameObject infoSuzuki;
    public GameObject infoBMW;
    public GameObject infoYamaha;

    // Animaciones de los modelos
    Animation ASuzuki;
    Animation ABMW;
    Animation AYamaha;

    // Definición de estado de visibilidad de las fichas
    bool visibleSuzuki = true;
    bool visibleBMW = true;
    bool visibleYamaha = true;

    
    void Start()
    {
        // Obtenemos los componentes de Animation de las fichas
        ASuzuki = infoSuzuki.GetComponent<Animation>();
        ABMW = infoBMW.GetComponent<Animation>();
        AYamaha = infoYamaha.GetComponent<Animation>();
    }

    // Funciones encargadas de activar la animación de las fichas
    public void infoSuzukiPulsada(){
        if(visibleSuzuki){
            ASuzuki["Suzuki"].speed = 1;
            ASuzuki.Play();
            visibleSuzuki = false;
        }
    }

    public void infoBMWPulsada(){
        if(visibleBMW){
            ABMW["BMW"].speed = 1;
            ABMW.Play();
            visibleBMW = false;
        }
    }

    public void infoYamahaPulsada(){
        if(visibleYamaha){
            AYamaha["Yamaha"].speed = 1;
            AYamaha.Play();
            visibleYamaha = false;
        }
    }

    // Función encargada de ocultar la ficha técnica que se este mostrando
    // dentro del canvas
    public void ventanaNoPulsada(){
        string nombreBoton = EventSystem.current.currentSelectedGameObject.name;

        if(nombreBoton != "Suzuki GSX-S1000" && !visibleSuzuki){
            ASuzuki["Suzuki"].speed = -1;
            ASuzuki["Suzuki"].time = ASuzuki["Suzuki"].length;
            ASuzuki.Play();
            visibleSuzuki = true;
        }

        if(nombreBoton != "BMW R18" && !visibleBMW){
            ABMW["BMW"].speed = -1;
            ABMW["BMW"].time = ABMW["BMW"].length;
            ABMW.Play();
            visibleBMW = true;
        }

        if(nombreBoton != "Yamaha-YZF-R7" && !visibleYamaha){
            AYamaha["Yamaha"].speed = -1;
            AYamaha["Yamaha"].time = AYamaha["Yamaha"].length;
            AYamaha.Play();
            visibleYamaha = true;
        }
    }
}
