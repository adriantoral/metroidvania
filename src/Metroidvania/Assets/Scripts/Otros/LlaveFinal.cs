using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveFinal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clon") SceneLoader.cargarFinal();
    }
}
