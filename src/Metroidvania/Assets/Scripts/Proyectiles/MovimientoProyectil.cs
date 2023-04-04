using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoProyectil : MonoBehaviour
{
    public int damage;
    public float velocicadProyectil;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (velocicadProyectil * MovimientoPersonaje.movimientoHorizontal));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ignorar" || other.gameObject.tag == "Player" || other.gameObject.tag == "Clon" || this.gameObject.tag == "Enemigo") { } // Ignorar el contacto

        else if (other.gameObject.tag == "PuertaDestruible" && Personaje.hasDestructorParedes)
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject);
        }

        else if (other.gameObject.tag == "Enemigo" && this.gameObject.tag != "Enemigo")
        {
            other.GetComponent<Enemigo>().herir(this.damage);
            Destroy(this.gameObject);
        }

        else Destroy(this.gameObject);
    }
}
