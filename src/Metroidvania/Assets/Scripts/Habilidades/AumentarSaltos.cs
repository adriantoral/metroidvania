using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarSaltos : MonoBehaviour
{
    public int numeroSaltos;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<Informativo>().informar("Ahora puedes hacer " + (MovimientoPersonaje.numeroMaximoSaltos + this.numeroSaltos) + " saltos.");
            MovimientoPersonaje.numeroMaximoSaltos += this.numeroSaltos;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
