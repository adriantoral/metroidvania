using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class UP_EvTrigger : MonoBehaviour
{
    [SerializeField] bool filtrarPorTag = false;
    [TagSelector, SerializeField] string tagTrigger = null;
    [SerializeField] bool enviarMensaje = false;
    [SerializeField] string mensaje = null;
    [SerializeField] float tiempoEntreEventos = 0;
    [SerializeField] UP_NoArgsUnityEvent alEntrarEnTrigger = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alPermanecerEnTrigger = new UP_NoArgsUnityEvent();
    [SerializeField] UP_NoArgsUnityEvent alSalirDeTrigger = new UP_NoArgsUnityEvent();

    float tiempoEspera = 0;

    private void FixedUpdate()
    {
        tiempoEspera = Mathf.Max(0, tiempoEspera - Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tiempoEspera == 0 && (!filtrarPorTag || other.gameObject.CompareTag(tagTrigger)))
        {
            tiempoEspera = tiempoEntreEventos;
            if (alEntrarEnTrigger != null) { alEntrarEnTrigger.Invoke(); }
            if (enviarMensaje) { EnviarMensaje(other); }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (tiempoEspera == 0 && (!filtrarPorTag || other.gameObject.CompareTag(tagTrigger)))
        {
            tiempoEspera = tiempoEntreEventos;
            if (alPermanecerEnTrigger != null) { alPermanecerEnTrigger.Invoke(); }
            if (enviarMensaje) { EnviarMensaje(other); }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (tiempoEspera == 0 && (!filtrarPorTag || other.gameObject.CompareTag(tagTrigger)))
        {
            tiempoEspera = tiempoEntreEventos;
            if (alSalirDeTrigger != null) { alSalirDeTrigger.Invoke(); }
            if (enviarMensaje) { EnviarMensaje(other); }
        }
    }

    void EnviarMensaje(Collider2D collider)
    {
        Component target = collider.attachedRigidbody;
        if (target == null) { target = collider; }

        UP_EvMensaje[] evMensajes = target.GetComponentsInChildren<UP_EvMensaje>();
        for (int i = 0; i < evMensajes.Length; ++i)
        {
            evMensajes[i].LanzarEventoMensaje(mensaje);
        }
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(UP_EvTrigger))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_EvTrigger componente = target as UP_EvTrigger;

            serializedObject.Update();

            EditorGUILayout.LabelField("Filtro", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("filtrarPorTag"));
            if (componente.filtrarPorTag) { EditorGUILayout.PropertyField(serializedObject.FindProperty("tagTrigger")); }

            EditorGUILayout.LabelField("Mensajes", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enviarMensaje"));
            if (componente.enviarMensaje) { EditorGUILayout.PropertyField(serializedObject.FindProperty("mensaje")); }

            EditorGUILayout.LabelField("Eventos", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tiempoEntreEventos"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alEntrarEnTrigger"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alPermanecerEnTrigger"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alSalirDeTrigger"));
            serializedObject.ApplyModifiedProperties();

        }
    }

#endif

}
