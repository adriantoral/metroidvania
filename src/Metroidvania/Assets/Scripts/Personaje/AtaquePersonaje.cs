using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePersonaje : MonoBehaviour
{
    public GameObject balaDerecha, balaIzquierda, balaDerechaDestruible, balaIzquierdaDestruible;
    public Transform posicionPistolaDerecha, posicionPistolaIzquierda;
    public static bool estaDisparando = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(
                MovimientoPersonaje.movimientoHorizontal == -1 && Personaje.hasDestructorParedes ? balaIzquierdaDestruible :
                MovimientoPersonaje.movimientoHorizontal == 1 && Personaje.hasDestructorParedes ? balaDerechaDestruible :
                MovimientoPersonaje.movimientoHorizontal == -1 ? balaIzquierda :
                balaDerecha,
                MovimientoPersonaje.movimientoHorizontal == -1 ? this.posicionPistolaIzquierda.position : this.posicionPistolaDerecha.position, Quaternion.identity
                );

            AtaquePersonaje.estaDisparando = true;
        }
    }
}
