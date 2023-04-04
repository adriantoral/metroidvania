using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public GameObject balaDerecha, balaIzquierda;

    public void atacar()
    {
        Instantiate(balaDerecha, this.GetComponent<Transform>().position, Quaternion.identity);
        Instantiate(balaIzquierda, this.GetComponent<Transform>().position, Quaternion.identity); 

    }
}
