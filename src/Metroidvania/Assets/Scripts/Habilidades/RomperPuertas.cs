using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RomperPuertas : MonoBehaviour
{
    public Image imagen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<Informativo>().informar("Ahora puedes romper paredes.");
            imagen.enabled = true;
            Personaje.hasDestructorParedes = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
