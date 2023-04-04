using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void cargarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public static void cargarMuerte()
    {
        SceneManager.LoadScene(2);
    }

    public static void cargarFinal()
    {
        SceneManager.LoadScene(3);
    }
}
