using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonar : MonoBehaviour
{
    public GameObject clon;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2) && Personaje.hasClone)
            if (Clon.actualClones++ < Clon.maxClones)
            {
                this.GetComponent<Camera>().orthographicSize = 16;
                Instantiate(clon, this.GetComponent<Transform>().position + new Vector3(((1 + Clon.actualClones) * MovimientoPersonaje.movimientoHorizontal), 0, 0), Quaternion.identity);
            }

        if (Input.GetMouseButtonDown(1) && Personaje.hasClone)
        {
            Clon.actualClones = 0;
            this.GetComponent<Camera>().orthographicSize = 8;
        }
    }
}
