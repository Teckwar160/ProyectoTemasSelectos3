using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Joystick encarhado de mover la motocicleta
    public VariableJoystick control;

    // Variables de control de posición
    Transform jugador;
    float posicionZ;
    char flag = 'n';

    void Update()
    {
        // Obtenemos el componente de posición del modelo
        jugador = GetComponent<Transform>();

        // Condicionales encargados de definir la posición del modelo dependiendo de la posición del joystick y
        // de la posición anterior.
        if(control.Vertical > 0 && flag != 'u' && flag != 'd'){
            jugador.position = new Vector3(jugador.position.x, jugador.position.y , jugador.position.z + 0.5f);
            flag = 'u';

        } else if(control.Vertical < 0 && flag != 'u' && flag != 'd'){
            jugador.position = new Vector3(jugador.position.x, jugador.position.y , jugador.position.z - 0.5f);
            flag = 'd';

        }else if(control.Vertical == 0){

            // Reseteo de la posición del modelo en el centro del target.
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
