using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarCanvas : MonoBehaviour
{
    public Slider sliderVida;
    public Personaje personaje;

    private void Start()
    {
        sliderVida.maxValue = personaje.vida;
        sliderVida.value = personaje.vida;
    }

    // Update is called once per frame
    void Update()
    {
        sliderVida.value = personaje.vida;
    }
}
