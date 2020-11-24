using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public Transform target;
    private const float ORBITDISTANCE = 10.0f;
    //Quizá sea demasiado rápido
    private const float ORBITDEGREESPERSEC = 30f;
    //Posición de vector 0 inicial
    public Vector3 relativeDistance = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        if (target != null)
        {
            //Inicio una distancia de separación entre jugador y objeto
            relativeDistance = transform.position - target.position;
        }
    }
    void Orbit()
    {            
        if (target != null)
        {
            //Esto es para mantener las cajas a distancia
            transform.position = target.position + relativeDistance;
            //Rotación de las cajas
            transform.RotateAround (target.position, Vector3.up, ORBITDEGREESPERSEC * Time.deltaTime);
            //Esto es para resetear la posición relativa después de rotar
            relativeDistance = transform.position - target.position;
        }
    }
    void Update()
    {
        Orbit();
    }
}

//Debo poner 4 objetos con la frase "Restart?" que roten alrededor del jugador.
//Estos objetos deben reiniciar la partida del jugador, como mínimo tengo que dejar esto hecho para cuando el script del reinicio esté listo.
