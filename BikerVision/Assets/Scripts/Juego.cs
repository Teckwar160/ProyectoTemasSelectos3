using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public Transform target;
    int puntaje = 0;
    public Transform jugador;
    public GameObject caja;
    float numeroAleatorio;
    int numCajas = 0;
    float cambio = 0f;
    int velocidad = 2;
    int separacion = 0;
    List<GameObject> listaCajas = new List<GameObject>();
    public bool inicio = false;

    void Update()
    {
        if(inicio){
            if(numCajas < 6){

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
                    listaCajas[i].transform.position = new Vector3(listaCajas[i].transform.position.x - velocidad * Time.deltaTime, 
                                                                    listaCajas[i].transform.position.y,
                                                                    listaCajas[i].transform.position.z);
                    
                    if(listaCajas[i].transform.position.x < jugador.position.x-5){
                        if(listaCajas[i].transform.position.z == jugador.position.z){
                            puntaje-=1;
                        }else{
                            puntaje+=1;
                        }

                        Destroy(listaCajas[i]);
                        listaCajas.RemoveAt(i);
                        numCajas--;

                        if(puntaje < -10){
                            inicio = false;
                        }
                        
                    }
                }
        }else{
            puntaje = 0;

            for(int i=0; i<listaCajas.Count; i++){
                Destroy(listaCajas[i]);
                listaCajas.RemoveAt(i);
            }
        } 
    }
}
