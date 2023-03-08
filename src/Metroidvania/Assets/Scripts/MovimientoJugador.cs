using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D personaje;
    private Animator animador;
    private Transform transformacion;

    public int velocidadVertical, velocidadHorizontal;
    public RuntimeAnimatorController animacionIdle, animacionCorriendo;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        transformacion = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            personaje.AddForce(Vector2.up * velocidadVertical);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transformacion.localScale = new Vector3(-1, 1, 1);
            animador.runtimeAnimatorController = animacionCorriendo;
            personaje.AddForce(Vector2.left * velocidadHorizontal);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transformacion.localScale = new Vector3(1, 1, 1);
            animador.runtimeAnimatorController = animacionCorriendo;
            personaje.AddForce(Vector2.right * velocidadHorizontal);
        }

        else animador.runtimeAnimatorController = animacionIdle;
    }
}
