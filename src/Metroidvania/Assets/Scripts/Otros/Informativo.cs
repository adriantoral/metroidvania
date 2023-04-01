using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informativo : MonoBehaviour
{
    public TextMesh textoInformativo;
    public string textoInformar;

    // Start is called before the first frame update
    void informar()
    {
        textoInformativo.text = textoInformar;
        textoInformativo.gameObject.SetActive(true);
    }
}
