using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    // Variables publicas necesarias para la jugabilidad
    public Transform targetMoto1;
    public Transform jugadorMoto1;
    public Transform targetMoto2;
    public Transform jugadorMoto2;
    public Transform targetMoto3;
    public Transform jugadorMoto3;
    public GameObject caja;
    public int puntaje = 0;

    // Variables para el control del juego
    Transform target;
    Transform jugador;
    float numeroAleatorio;
    int numCajas = 0;
    float cambio = 0f;
    int velocidad = 5;
    int separacion = 0;
    int seleccion;
    List<GameObject> listaCajas = new List<GameObject>();
    bool inicio = false;

    // Función encargada de destruir las cajas instanciadas
    public void destruirCajas(GameObject c){
        // Eliminamos la caja
        listaCajas.Remove(c);
        Destroy(c);

        // Decrementamos el número de cajas
        numCajas--;

    }


    // Funciones para seleccionar  que modelo se mostrara
    public void seleccionMoto1(){
        seleccion = 0;
    }

    public void seleccionMoto2(){
        seleccion = 1;
    }

    public void seleccionMoto3(){
        seleccion = 2;
    }

    public void setInicioTrue(){
        inicio = true;
    }

    public void setInicioFalse(){
        inicio = false;
    }

    void Update()
    {
        // Condicional que controla el inicio y fin del juego
        if(inicio && puntaje >= -10){

            // Definicion del jugador dependiendo del target
            switch(seleccion){
                case 0:
                    target = targetMoto1;
                    jugador = jugadorMoto1;
                    break;
                case 1:
                    target = targetMoto2;
                    jugador = jugadorMoto2;
                    break;
                case 2:
                    target = targetMoto3;
                    jugador = jugadorMoto3;
                    break;
            }

            // Condicional para mantener la instanciación de cajas estable
            if(numCajas < 40){

                // Separación para evitar que las cajas se agrupen
                if(separacion == 0){
                    separacion = 10;
                }else{
                    separacion = 0;
                }

                // Determinación aleatorio de la posición de las cajas
                numeroAleatorio = Random.Range(0f, 2f);

                switch(numeroAleatorio){
                    case 0:
                        cambio = 0.5f;
                        break;
                    case 1:
                        cambio = -0.5f;
                        break;
                    case 2:
                        cambio = 0;
                        break;
                }

                // Instanciación de la caja, asiganción de nombre y posicionamiento de la misma
                GameObject nuevaCaja = Instantiate(caja);
                nuevaCaja.gameObject.name = "Caja";
                nuevaCaja.transform.SetParent(target);
                nuevaCaja.transform.position = new Vector3(jugador.position.x+15+separacion, jugador.position.y, jugador.position.z + cambio);
                nuevaCaja.transform.rotation = Quaternion.identity;

                // Se agrega a una lista para tener un control de las mismas
                listaCajas.Add(nuevaCaja);
                numCajas++;
            }

            // Bucle encargado de mover las cajas dentro del espacio
            for(int i=0; i<listaCajas.Count; i++){
                Vector3 tmp = listaCajas[i].transform.position;
                tmp.x = listaCajas[i].transform.position.x - velocidad * Time.deltaTime;
                tmp.y = jugador.position.y;
                listaCajas[i].transform.position = tmp;
                    
                // Condicional encargado de la destrucción de las cajas
                if(listaCajas[i].transform.position.x < jugador.position.x-2){
                    puntaje++;     
                    destruirCajas(listaCajas[i]);            
                }
            }
        }else{
            // Reseteo de variables de juego
            inicio = false;
            puntaje = 0;
            for(int i=0; i<listaCajas.Count; i++){
                destruirCajas(listaCajas[i]);
            }
        } 
        
    }
}