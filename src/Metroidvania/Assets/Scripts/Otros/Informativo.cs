using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Informativo : MonoBehaviour
{
    public TextMeshProUGUI textoInformativo;

    public void informar(string textoInformar)
    {
        textoInformativo.text = textoInformar;
        textoInformativo.gameObject.SetActive(true);
        StartCoroutine(QuitarTexto());
    }

    IEnumerator QuitarTexto()
    {
        yield return new WaitForSeconds(2);
        textoInformativo.gameObject.SetActive(false);
    }
}
