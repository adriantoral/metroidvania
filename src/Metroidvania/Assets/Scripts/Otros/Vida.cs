using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public Personaje personaje;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon")
        {
            this.GetComponent<Informativo>().informar("Te has curado 20 de vida.");
            personaje.curar(20);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
