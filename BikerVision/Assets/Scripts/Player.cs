using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick control;
    Transform jugador;
    float posicionZ;
    char flag = 'n';

    void Update()
    {
        jugador = GetComponent<Transform>();

        if(control.Vertical > 0 && flag != 'u' && flag != 'd'){
            jugador.position = new Vector3(jugador.position.x, jugador.position.y , jugador.position.z + 0.5f);
            flag = 'u';

        } else if(control.Vertical < 0 && flag != 'u' && flag != 'd'){
            jugador.position = new Vector3(jugador.position.x, jugador.position.y , jugador.position.z - 0.5f);
            flag = 'd';

        }else if(control.Vertical == 0){

            if(flag == 'u'){
                posicionZ = jugador.position.z - 0.5f;
            }else if(flag == 'd'){
                posicionZ = jugador.position.z + 0.5f;
            }else{
                posicionZ = jugador.position.z;
            }

            jugador.position = new Vector3(jugador.position.x, jugador.position.y , posicionZ);
            flag = 'n';
        }
    }
}
