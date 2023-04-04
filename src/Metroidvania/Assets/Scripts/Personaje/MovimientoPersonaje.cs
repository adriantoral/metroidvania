using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D rigidbodyPersonaje;
    private Animator animatorPersonaje;
    private Transform transformPersonaje;
    private bool puedeMoverse;

    public Personaje personaje;
    public RuntimeAnimatorController animacionIdle, animacionCorriendo, animacionDisparoCorriendo, animacionDisparoQuieto;
    public static int movimientoHorizontal = 1, numeroMaximoSaltos = 1;
    public int numeroSaltos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") this.numeroSaltos = MovimientoPersonaje.numeroMaximoSaltos;
        
        if (collision.gameObject.tag == "Techo") this.puedeMoverse = false;
        else this.puedeMoverse = true;
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
            if (Input.GetAxisRaw("Horizontal") == -1 && this.puedeMoverse)
            {
                MovimientoPersonaje.movimientoHorizontal = -1;

                this.GetComponent<SpriteRenderer>().flipX = true;

                if (AtaquePersonaje.estaDisparando) this.animatorPersonaje.runtimeAnimatorController = animacionDisparoCorriendo;
                else this.animatorPersonaje.runtimeAnimatorController = animacionCorriendo;

                this.transformPersonaje.position = new Vector3(
                    this.transformPersonaje.position.x - this.personaje.velocidadHorizontal,
                    this.transformPersonaje.position.y,
                    this.transformPersonaje.position.z
                );
            }

            else if (Input.GetAxisRaw("Horizontal") == 1 && this.puedeMoverse)
            {
                MovimientoPersonaje.movimientoHorizontal = 1;

                this.GetComponent<SpriteRenderer>().flipX = false;

                if (AtaquePersonaje.estaDisparando) this.animatorPersonaje.runtimeAnimatorController = animacionDisparoCorriendo;
                else this.animatorPersonaje.runtimeAnimatorController = animacionCorriendo;

                this.transformPersonaje.position = new Vector3(
                    transformPersonaje.position.x + this.personaje.velocidadHorizontal,
                    transformPersonaje.position.y,
                    transformPersonaje.position.z
                );
            }

            else if (AtaquePersonaje.estaDisparando) AtaquePersonaje.estaDisparando = false;

            else this.animatorPersonaje.runtimeAnimatorController = animacionIdle;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbodyPersonaje = GetComponent<Rigidbody2D>();
        this.animatorPersonaje = GetComponent<Animator>();
        this.transformPersonaje = GetComponent<Transform>();
        this.puedeMoverse = true;
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
