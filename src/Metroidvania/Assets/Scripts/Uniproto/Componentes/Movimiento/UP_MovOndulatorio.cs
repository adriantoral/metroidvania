using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UP_MovOndulatorio : MonoBehaviour {

    public enum TipoMovimiento
    {
        Horizontal, Vertical
    }

    [SerializeField] TipoMovimiento tipoMovimiento;
    [SerializeField] float amplitud = 1;
    [SerializeField] float frecuencia = 1;

    float tiempoAleatorio;
    float ultimoIncremento;

    void Awake()
    {
        tiempoAleatorio = Mathf.PI * 2 * Random.Range(0, 1 / frecuencia);
    }

    void OnEnable()
    {
        ultimoIncremento = CalcularOscilacion();
    }

    void FixedUpdate () {
        Vector3 posicion = transform.position;
        if(tipoMovimiento == TipoMovimiento.Horizontal)
        {
            float nuevoIncremento = CalcularOscilacion();
            posicion.x += nuevoIncremento - ultimoIncremento;
            ultimoIncremento = nuevoIncremento;
        }
        else if(tipoMovimiento == TipoMovimiento.Vertical)
        {
            float nuevoIncremento = CalcularOscilacion();
            posicion.y += nuevoIncremento - ultimoIncremento;
            ultimoIncremento = nuevoIncremento;
        }
        transform.position = posicion;
	}

    float CalcularOscilacion()
    {
        return amplitud * Mathf.Sin(frecuencia * (Time.time + tiempoAleatorio));
    }
}
