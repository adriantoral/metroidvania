using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoClon : MonoBehaviour
{
    public Image imagen;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon")
        {
            this.GetComponent<Informativo>().informar("Tu clones ahora pueden disparar.");
            imagen.enabled = true;
            Clon.puedeDisparar = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
