using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puente : MonoBehaviour
{
    public Collider2D puente;

    void Update()
    {
        if ((Input.GetAxisRaw("Vertical") == -1) || (Input.GetAxisRaw("Vertical") == 1)) puente.enabled = false;
        else puente.enabled = true;
    }
}
