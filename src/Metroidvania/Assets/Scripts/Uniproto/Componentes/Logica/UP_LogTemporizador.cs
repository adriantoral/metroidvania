using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class UP_LogTemporizador : MonoBehaviour {

    [SerializeField] float tiempoInicial = 1;
    [SerializeField] bool recurrente = false;
    [SerializeField] float tiempoRecurrente = 1;
    [SerializeField] bool iniciarEnAwake = true;
    [SerializeField] UP_NoArgsUnityEvent alSaltarTemporizador = new UP_NoArgsUnityEvent();
    
    bool iniciado = false;
    bool reactivarAlHabilitar = false;

    void Awake()
    {
        if(iniciarEnAwake)
        {
            UP_IniciarTemporizador();
        }
    }

    void OnEnable()
    {
        if(reactivarAlHabilitar)
        {
            reactivarAlHabilitar = false;
            UP_IniciarTemporizador();
        }
    }

    void OnDisable()
    {
        if(iniciado) { reactivarAlHabilitar = true; }
        UP_DetenerTemporizador();
    }

    public void UP_IniciarTemporizador()
    {
        if(!iniciado)
        { 
            iniciado = true;
            if (recurrente)
            {
                InvokeRepeating("EventoTemporizador", tiempoInicial, tiempoRecurrente);
            }
            else
            {
                Invoke("EventoTemporizador", tiempoInicial);
            }
        }
    }

    public void UP_DetenerTemporizador()
    {
        if(iniciado)
        {
            iniciado = false;
            CancelInvoke();
        }        
    }

    void EventoTemporizador()
    {
        alSaltarTemporizador.Invoke();
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(UP_LogTemporizador))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_LogTemporizador temp = target as UP_LogTemporizador;

            serializedObject.Update();            

            EditorGUILayout.PropertyField(serializedObject.FindProperty("tiempoInicial"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("recurrente"));            
            if(temp.recurrente)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("tiempoRecurrente"));                
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("iniciarEnAwake"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alSaltarTemporizador"));

            serializedObject.ApplyModifiedProperties();
        }
    }

#endif

}
