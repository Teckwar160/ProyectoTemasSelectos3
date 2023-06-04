using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public Transform targetMoto1;
    public Transform jugadorMoto1;
    public Transform targetMoto2;
    public Transform jugadorMoto2;
    public Transform targetMoto3;
    public Transform jugadorMoto3;
    Transform target;
    Transform jugador;
    public int puntaje = 0;
    public GameObject caja;
    float numeroAleatorio;
    int numCajas = 0;
    float cambio = 0f;
    int velocidad = 3;
    int separacion = 0;
    int seleccion;
    List<GameObject> listaCajas = new List<GameObject>();
    bool inicio = false;

    public void destruirCajas(GameObject c){
        listaCajas.Remove(c);
        Destroy(c);
        numCajas--;

    }

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
        
        if(inicio && puntaje >= -10){

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

            if(numCajas < 20){
                if(separacion == 0){
                    separacion = 10;
                }else{
                    separacion = 0;
                }
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

                GameObject nuevaCaja = Instantiate(caja);
                nuevaCaja.gameObject.name = "Caja";
                nuevaCaja.transform.SetParent(target);
                nuevaCaja.transform.position = new Vector3(jugador.position.x+10+separacion, jugador.position.y, jugador.position.z + cambio);
                nuevaCaja.transform.rotation = Quaternion.identity;
                listaCajas.Add(nuevaCaja);
                numCajas++;
                if(separacion == 0){
                    separacion = 10;
                }else{
                    separacion = 0;
                }
            }

            for(int i=0; i<listaCajas.Count; i++){
                Vector3 tmp = listaCajas[i].transform.position;
                tmp.x = listaCajas[i].transform.position.x - velocidad * Time.deltaTime;
                tmp.y = jugador.position.y;
                listaCajas[i].transform.position = tmp;
                    
                if(listaCajas[i].transform.position.x < jugador.position.x-5){
                    puntaje++;     
                    destruirCajas(listaCajas[i]);            
                }
            }
        }else{
            inicio = false;
            puntaje = 0;
            for(int i=0; i<listaCajas.Count; i++){
                destruirCajas(listaCajas[i]);
            }
        } 
        
    }
}