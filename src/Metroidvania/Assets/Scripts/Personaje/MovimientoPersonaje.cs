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
    public static int movimientoHorizontal = 1, numeroMaximoSaltos = 1;
    public int numeroSaltos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.numeroSaltos = MovimientoPersonaje.numeroMaximoSaltos;
    }

    void moverPersonaje(bool direccion)
    {
        if (!direccion)
        {
            if (Input.GetKeyDown(KeyCode.Space) && numeroSaltos > 0)
            {
                this.rigidbodyPersonaje.AddForce(Vector2.up * this.personaje.velocidadVertical);
                this.numeroSaltos--;
            }
        }

        else if (direccion)
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                MovimientoPersonaje.movimientoHorizontal = -1;

                this.transformPersonaje.localScale = new Vector3(
                    -Mathf.Abs(this.transformPersonaje.localScale.x),
                    this.transformPersonaje.localScale.y,
                    this.transformPersonaje.localScale.z
                    );

                this.animatorPersonaje.runtimeAnimatorController = animacionCorriendo;

                this.transformPersonaje.position = new Vector3(
                    this.transformPersonaje.position.x - this.personaje.velocidadHorizontal,
                    this.transformPersonaje.position.y,
                    this.transformPersonaje.position.z
                );
            }

            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                MovimientoPersonaje.movimientoHorizontal = 1;

                this.transformPersonaje.localScale = new Vector3(
                    Mathf.Abs(this.transformPersonaje.localScale.x),
                    this.transformPersonaje.localScale.y,
                    this.transformPersonaje.localScale.z
                    );

                this.animatorPersonaje.runtimeAnimatorController = this.animacionCorriendo;

                this.transformPersonaje.position = new Vector3(
                    transformPersonaje.position.x + this.personaje.velocidadHorizontal,
                    transformPersonaje.position.y,
                    transformPersonaje.position.z
                );
            }

            else this.animatorPersonaje.runtimeAnimatorController = animacionIdle;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbodyPersonaje = GetComponent<Rigidbody2D>();
        this.animatorPersonaje = GetComponent<Animator>();
        this.transformPersonaje = GetComponent<Transform>();
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
