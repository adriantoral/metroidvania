using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePersonaje : MonoBehaviour
{
    public int damage;
    public GameObject balaDerecha, balaIzquierda, balaDerechaDestruible, balaIzquierdaDestruible;
    public RuntimeAnimatorController animacionDisparoCorriendo, animacionDisparoQuieto;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Instantiate(
            MovimientoPersonaje.movimientoHorizontal == -1 && Personaje.hasDestructorParedes ? balaIzquierdaDestruible :
            MovimientoPersonaje.movimientoHorizontal == 1 && Personaje.hasDestructorParedes ? balaDerechaDestruible :
            MovimientoPersonaje.movimientoHorizontal == -1 ? balaIzquierda :
            balaDerecha,
            this.GetComponent<Transform>().position, Quaternion.identity);
    }
}
