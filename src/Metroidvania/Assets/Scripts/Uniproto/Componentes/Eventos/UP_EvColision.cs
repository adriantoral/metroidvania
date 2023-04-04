using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public class UP_EvColision : MonoBehaviour {

    [SerializeField] bool filtrarPorTag = false;    
    [TagSelector,SerializeField] string tagColision = null;
    [SerializeField] bool enviarMensaje = false;
    [SerializeField] string mensaje = null;
    [SerializeField] UP_NoArgsUnityEvent alDetectarColision = new UP_NoArgsUnityEvent();
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!filtrarPorTag || collision.gameObject.CompareTag(tagColision))
        {
            alDetectarColision.Invoke();
            if (enviarMensaje) { EnviarMensaje(collision.collider); }
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

    [UnityEditor.CustomEditor(typeof(UP_EvColision))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_EvColision componente = target as UP_EvColision;

            serializedObject.Update();

            EditorGUILayout.LabelField("Filtro", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("filtrarPorTag"));
            if (componente.filtrarPorTag) { EditorGUILayout.PropertyField(serializedObject.FindProperty("tagColision")); }

            EditorGUILayout.LabelField("Mensajes", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enviarMensaje"));
            if(componente.enviarMensaje) { EditorGUILayout.PropertyField(serializedObject.FindProperty("mensaje")); }

            EditorGUILayout.LabelField("Eventos", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("alDetectarColision"));
            serializedObject.ApplyModifiedProperties();

        }
    }

#endif
}
