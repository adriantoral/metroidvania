using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoProyectilEnemigo : MonoBehaviour
{
    public int damage;
    public float velocicadProyectil;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * velocicadProyectil);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "Vida") { } // Ignorar el contacto

        else if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon")
        {
            other.GetComponent<Personaje>().herir(this.damage);
            Destroy(this.gameObject);
        }

        else Destroy(this.gameObject);
    }
}
