using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UP_EvCreacionDestruccion : MonoBehaviour {

    [SerializeField] UP_NoArgsUnityEvent alCrearme;
    [SerializeField] UP_NoArgsUnityEvent alDestruirme;

    bool saliendo;

    void Start () {
        alCrearme.Invoke();
	}

    void OnDestroy()
    {
        if(!saliendo)
        {
            alDestruirme.Invoke();
        }        
    }
    
    void OnApplicationQuit()
    {
        saliendo = true;
    }
}
