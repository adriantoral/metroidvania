using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UP_EvInputTeclado : MonoBehaviour {

    [SerializeField] string tecla = "space";
    [SerializeField] float tiempoEntreEventos = 0;
    
    [SerializeField] UP_NoArgsUnityEvent alPulsarTecla = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alMantenerTecla = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alSoltarTecla = new UP_NoArgsUnityEvent();

    float tiempoEspera = 0;    
    	
	void Update ()
    {
        tiempoEspera = Mathf.Max(0, tiempoEspera - Time.deltaTime);
        if (tiempoEspera == 0 && Input.GetKeyDown(tecla))
        {
            tiempoEspera = tiempoEntreEventos;
            alPulsarTecla.Invoke();
        }
        if (tiempoEspera == 0 && Input.GetKey(tecla))
        {
            tiempoEspera = tiempoEntreEventos;
            alMantenerTecla.Invoke();
        }
        if (tiempoEspera == 0 && Input.GetKeyUp(tecla))
        {
            tiempoEspera = tiempoEntreEventos;
            alSoltarTecla.Invoke();
        }        
            
	}

}
