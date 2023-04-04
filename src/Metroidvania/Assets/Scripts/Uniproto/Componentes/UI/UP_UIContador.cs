using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UP_UIContador : MonoBehaviour {

    
    [SerializeField] UP_LogContador contador;
    [SerializeField] string prefijo;
    [SerializeField] string sufijo;

    Text text;
    int ultimoValor;

    void Awake()
    {
        text = GetComponent<Text>();
        Assert.IsNotNull(text, "El componente UIContador debe añadirse a un objeto de UI con componente Text");
        Assert.IsNotNull(contador, "El componente UIContador necesita una referencia a un componente Contador");

        ActualizarTexto();
    }

    void Update()
    {
        if(ultimoValor != contador.Valor)
        {
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        ultimoValor = contador.Valor;
        text.text = prefijo + contador.Valor + sufijo;
    }


}
