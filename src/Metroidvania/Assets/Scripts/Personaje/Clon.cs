using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clon : MonoBehaviour
{
    public static int actualClones, maxClones;
    public static bool puedeDisparar;

    private void Start()
    {
        if (Clon.puedeDisparar) this.GetComponent<AtaquePersonaje>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(1) && Personaje.hasClone) || this.GetComponent<Personaje>().vida <= 0) Destroy(this.gameObject);
    }
}
