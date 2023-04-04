using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class UP_LogContador : MonoBehaviour {

    public enum Comparacion
    {
        MenorOIgual,
        Igual,
        MayorOIgual        
    }

    [SerializeField] int valor;
    [SerializeField] int multiplicador = 1;
    [SerializeField] bool alertarSiAlcanzaValor;
    [SerializeField] int valorObjetivo;
    [SerializeField] Comparacion comparacion;
    [SerializeField] UP_NoArgsUnityEvent siAlcanzaCifra;

    public int Valor
    {
        get { return valor; }
    }

    public void UP_EstablecerMultiplicador(int multiplicador)
    {
        this.multiplicador = multiplicador;
    }

    public void UP_ModificarMultiplicador(int cantidad)
    {
        multiplicador += cantidad;
    }

    public void UP_EstablecerContador(int valor)
    {
        this.valor = valor;
        ComprobarAlerta();
    }

    public void UP_ModificarContador(int cantidad)
    {
        valor += cantidad * multiplicador;
        ComprobarAlerta();
    }

    private void ComprobarAlerta()
    {
        if (alertarSiAlcanzaValor)
        {
            switch (comparacion)
            {
                case Comparacion.Igual:
                    if (valor == valorObjetivo) { LanzarEvento(); }
                    break;
                case Comparacion.MayorOIgual:
                    if (valor >= valorObjetivo) { LanzarEvento(); }
                    break;
                case Comparacion.MenorOIgual:
                    if (valor <= valorObjetivo) { LanzarEvento(); }
                    break;
            }
        }
    }

    void LanzarEvento()
    {
        if (siAlcanzaCifra != null) { siAlcanzaCifra.Invoke(); }
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(UP_LogContador))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_LogContador cont = target as UP_LogContador;

            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("valor"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("multiplicador"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alertarSiAlcanzaValor"));
            if (cont.alertarSiAlcanzaValor)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("valorObjetivo"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("comparacion"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("siAlcanzaCifra"));                
            }

            serializedObject.ApplyModifiedProperties();

        }
    }

#endif

}
