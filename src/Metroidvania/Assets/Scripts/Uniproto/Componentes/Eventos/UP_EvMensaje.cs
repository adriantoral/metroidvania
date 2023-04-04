using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UP_EvMensaje : MonoBehaviour {

    [SerializeField] string mensaje;
    [SerializeField] UP_NoArgsUnityEvent alRecibirMensaje;    

	public void LanzarEventoMensaje(string mensaje)
    {
        if(this.mensaje == mensaje)
        {
            alRecibirMensaje.Invoke();
        }
    }
    
}
