using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AumentarSaltos : MonoBehaviour
{
    public Image imagen;
    public int numeroSaltos;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon")
        {
            this.GetComponent<Informativo>().informar("Ahora puedes hacer " + (MovimientoPersonaje.numeroMaximoSaltos + this.numeroSaltos) + " saltos.");
            imagen.enabled = true;
            MovimientoPersonaje.numeroMaximoSaltos += this.numeroSaltos;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
