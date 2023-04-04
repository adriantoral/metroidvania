using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_EvInputRaton : MonoBehaviour {

    public enum BotonRaton
    {
        ClicIzquierdo,
        ClicDerecho,
        ClicCentral
    }

    [SerializeField] BotonRaton boton = BotonRaton.ClicIzquierdo;
    [SerializeField] float tiempoEntreEventos = 0;

    [SerializeField] UP_NoArgsUnityEvent alPulsarBoton = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alMantenerBoton = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alSoltarBoton = new UP_NoArgsUnityEvent();

    float tiempoEspera = 0;


    void Update()
    {
        tiempoEspera = Mathf.Max(0, tiempoEspera - Time.deltaTime);

        if (tiempoEspera == 0 && Input.GetMouseButtonDown((int)boton))
        {
            tiempoEspera = tiempoEntreEventos;
            alPulsarBoton.Invoke();
        }
        if (tiempoEspera == 0 && Input.GetMouseButtonUp((int)boton))
        {
            tiempoEspera = tiempoEntreEventos;
            alSoltarBoton.Invoke();
        }        
        if (tiempoEspera == 0 && Input.GetMouseButton((int)boton))
        {
            tiempoEspera = tiempoEntreEventos;
            alMantenerBoton.Invoke();
        }        
    }

}
