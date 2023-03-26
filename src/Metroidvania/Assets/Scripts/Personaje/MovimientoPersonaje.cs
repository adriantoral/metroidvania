using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D rigidbodyPersonaje;
    private Animator animatorPersonaje;
    private Transform transformPersonaje;

    public Personaje personaje;
    public RuntimeAnimatorController animacionIdle, animacionCorriendo;
    public static int movimientoHorizontal = 1;

    void moverPersonaje(bool direccion)
    {
        if (!direccion)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbodyPersonaje.AddForce(Vector2.up * personaje.velocidadVertical);
            }
        }

        else if (direccion)
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                MovimientoPersonaje.movimientoHorizontal = -1;

                transformPersonaje.localScale = new Vector3(-Mathf.Abs(transformPersonaje.localScale.x), transformPersonaje.localScale.y, transformPersonaje.localScale.z);
                animatorPersonaje.runtimeAnimatorController = animacionCorriendo;

                transformPersonaje.position = new Vector3(
                    transformPersonaje.position.x - personaje.velocidadHorizontal,
                    transformPersonaje.position.y,
                    transformPersonaje.position.z
                );
            }

            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                MovimientoPersonaje.movimientoHorizontal = 1;

                transformPersonaje.localScale = new Vector3(Mathf.Abs(transformPersonaje.localScale.x), transformPersonaje.localScale.y, transformPersonaje.localScale.z);
                animatorPersonaje.runtimeAnimatorController = animacionCorriendo;

                transformPersonaje.position = new Vector3(
                    transformPersonaje.position.x + personaje.velocidadHorizontal,
                    transformPersonaje.position.y,
                    transformPersonaje.position.z
                );
            }

            else animatorPersonaje.runtimeAnimatorController = animacionIdle;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPersonaje = GetComponent<Rigidbody2D>();
        animatorPersonaje = GetComponent<Animator>();
        transformPersonaje = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.moverPersonaje(false);
    }

    private void FixedUpdate()
    {
        this.moverPersonaje(true);
    }
}
