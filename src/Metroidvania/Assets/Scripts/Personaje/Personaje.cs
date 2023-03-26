using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private int vidaMaxima;

    public int vida;
    public float velocidadHorizontal, velocidadVertical;
    public static bool hasJetpack, hasDestructorParedes, hasClone;

    private void Start()
    {
        this.vidaMaxima = this.vida;
    }

    public void curar(int cantidad)
    {
        this.vida += cantidad;
        if (this.vida > this.vidaMaxima) this.vida = this.vidaMaxima;
    }
}
