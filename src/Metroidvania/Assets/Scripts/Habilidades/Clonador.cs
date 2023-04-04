using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clonador : MonoBehaviour
{
    public Image imagen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon")
        {
            this.GetComponent<Informativo>().informar("Ahora puedes clonarte " + (Clon.maxClones + 1) + " vez.") ;
            imagen.enabled = true;
            Personaje.hasClone = true;
            Clon.maxClones++;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
