using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UP_EvActualizacion : MonoBehaviour {

    [SerializeField] bool usarBucleFisicas = false;

    [SerializeField] UP_NoArgsUnityEvent alActualizar;

    void Update()
    {
        if (!usarBucleFisicas)
        {
            alActualizar.Invoke();
        }
    }

    void FixedUpdate()
    {
        if (usarBucleFisicas)
        {
            alActualizar.Invoke();
        }
    }
}
