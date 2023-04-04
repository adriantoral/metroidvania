using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private int vidaMaxima;

    public int vida;
    public float velocidadHorizontal, velocidadVertical;

    private void Start()
    {
        this.vidaMaxima = this.vida;
    }

    private void Update()
    {
        if (this.vida <= 0)
        {
            if (this.GetComponent<BossFinal>()) this.GetComponent<BossFinal>().finalizar();
            Destroy(this.gameObject);
        }
    }

    public void curar(int cantidad)
    {
        this.vida += cantidad;
        if (this.vida > this.vidaMaxima) this.vida = this.vidaMaxima;
    }

    public void herir(int cantidad)
    {
        this.vida -= cantidad;
    }
}
