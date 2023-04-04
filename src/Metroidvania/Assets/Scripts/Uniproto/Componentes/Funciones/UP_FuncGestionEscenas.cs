using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UP_FuncGestionEscenas : MonoBehaviour {

    public void UP_CargarEscena(int numeroEscena)
    {
        if(numeroEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(numeroEscena);
        }
    }

    public void UP_CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);        
    }

    public void UP_CargarAnteriorEscena()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        int nivelAnterior = nivelActual - 1;
        if (nivelAnterior >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nivelAnterior);
        }
    }

    public void UP_CargarSiguienteEscena()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        int nivelSiguiente = nivelActual + 1;
        if(nivelSiguiente < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nivelSiguiente);
        }
    }

	public void UP_ReiniciarEscena()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nivelActual);
    }
    
}
