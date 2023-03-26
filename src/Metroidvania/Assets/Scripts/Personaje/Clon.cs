using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clon : MonoBehaviour
{
    public static int actualClones;
    public static int maxClones;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Personaje.hasClone) Destroy(this.gameObject);
    }
}
