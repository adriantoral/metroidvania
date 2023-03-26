using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Collider2D puerta;
    public Renderer puertaRenderer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            puerta.enabled = false;
            puertaRenderer.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
