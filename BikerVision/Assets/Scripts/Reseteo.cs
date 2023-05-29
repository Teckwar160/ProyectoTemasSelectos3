using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseteo : MonoBehaviour
{
    public Transform target;
    public Transform player;
    Transform targetT;
    public Vector3 posicion;
    public Vector3 rotacion;

    public void reinicio()
    {
        targetT = target.GetComponent<Transform>();
        player.position = new Vector3(targetT.position.x+posicion.x,targetT.position.y+posicion.y,
                                      targetT.position.z+posicion.z);
        player.rotation = Quaternion.Euler(rotacion);
    }
}
