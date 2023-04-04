using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public GameObject llaveFinal;

    public void finalizar()
    {
        Instantiate(llaveFinal, this.GetComponent<Transform>().position, Quaternion.identity);
    }
}
