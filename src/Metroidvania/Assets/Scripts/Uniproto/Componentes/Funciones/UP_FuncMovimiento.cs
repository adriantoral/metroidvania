using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UP_FuncMovimiento : MonoBehaviour {

    public enum TipoMovimiento
    {
        Local, Global
    }

    [SerializeField] TipoMovimiento tipoMovimiento;
    Rigidbody2D miRigidbody;


    void Awake()
    {
        miRigidbody = GetComponent<Rigidbody2D>();
    }

    public void UP_EstablecerPosicionX(float posX)
    {
        if (tipoMovimiento == TipoMovimiento.Global)
        {
            Vector3 posActual = this.transform.position;
            posActual.x = posX;
            this.transform.position = posActual;
        }
        else
        {
            Vector3 posActual = this.transform.localPosition;
            posActual.x = posX;
            this.transform.localPosition = posActual;
        }
    }

    public void UP_EstablecerPosicionY(float posVertical)
    {
        if (tipoMovimiento == TipoMovimiento.Global)
        {
            Vector3 posActual = this.transform.position;
            posActual.y = posVertical;
            this.transform.position = posActual;
        }
        else
        {
            Vector3 posActual = this.transform.localPosition;
            posActual.y = posVertical;
            this.transform.localPosition = posActual;
        }
    }

    public void UP_EstablecerRotacion(float rotacion)
    {
        if (tipoMovimiento == TipoMovimiento.Global)
        {
            Vector3 rotActual = this.transform.eulerAngles;
            rotActual.z = rotacion;
            this.transform.eulerAngles = rotActual;
        }
        else
        {
            Vector3 rotActual = this.transform.localEulerAngles;
            rotActual.z = rotacion;
            this.transform.localEulerAngles = rotActual;
        }
    }

    public void UP_MoverPosicionX(float movimiento)
    {
        bool enGlobal = (tipoMovimiento == TipoMovimiento.Global);
        Vector3 direccion = enGlobal ? Vector3.right : this.transform.right;
        miRigidbody.MovePosition(this.transform.position + direccion * movimiento);        
    }

    public void UP_MoverPosicionY(float movimiento)
    {
        bool enGlobal = (tipoMovimiento == TipoMovimiento.Global);
        Vector3 direccion = enGlobal ? Vector3.up : this.transform.up;
        miRigidbody.MovePosition(this.transform.position + direccion * movimiento);
    }

    public void UP_MoverRotacion(float rotacion)
    {
        miRigidbody.MoveRotation(this.transform.eulerAngles.z + rotacion);
    }

    public void UP_AñadirFuerzaY(float fuerza)
    {
        bool enGlobal = (tipoMovimiento == TipoMovimiento.Global);
        Vector3 direccion = enGlobal ? Vector3.up : this.transform.up;
        miRigidbody.AddForce(direccion * fuerza);
    }

    public void UP_AñadirFuerzaX(float fuerza)
    {
        bool enGlobal = (tipoMovimiento == TipoMovimiento.Global);
        Vector3 direccion = enGlobal ? Vector3.right : this.transform.right;
        miRigidbody.AddForce(direccion * fuerza);
    }

    public void UP_AñadirTorsion(float fuerza)
    {
        miRigidbody.AddTorque(fuerza);
    }

    public void UP_EstablecerVelocidadX(float velocidad)
    {
        if (tipoMovimiento == TipoMovimiento.Local)
        {
            Vector2 velocidadAux = miRigidbody.velocity;
            Vector2 localVelocidadAux = this.transform.InverseTransformVector(velocidadAux);
            localVelocidadAux.x = velocidad;
            miRigidbody.velocity = this.transform.TransformVector(localVelocidadAux);
        }
        else
        {
            Vector2 velocidadAux = miRigidbody.velocity;
            velocidadAux.x = velocidad;
            miRigidbody.velocity = velocidadAux;
        }
    }

    public void UP_EstablecerVelocidadY(float velocidad)
    {
        if (tipoMovimiento == TipoMovimiento.Local)
        {
            Vector2 velocidadAux = miRigidbody.velocity;
            Vector2 localVelocidadAux = this.transform.InverseTransformVector(velocidadAux);
            localVelocidadAux.y = velocidad;
            miRigidbody.velocity = this.transform.TransformVector(localVelocidadAux);
        }
        else
        {
            Vector2 velocidadAux = miRigidbody.velocity;
            velocidadAux.y = velocidad;
            miRigidbody.velocity = velocidadAux;
        }
    }    

    public void UP_EstablecerVelocidadAngular(float velocidad)
    {
        miRigidbody.angularVelocity = velocidad;
    }
    
    public void UP_InvertirEjeX(bool invertir)
    {
        Vector3 escala = this.transform.localScale;
        escala.x = Mathf.Abs(escala.x) * (invertir ? -1 : 1);
        this.transform.localScale = escala;
    }

}

