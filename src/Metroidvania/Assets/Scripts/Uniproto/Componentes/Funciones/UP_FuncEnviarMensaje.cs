using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UP_FuncEnviarMensaje : MonoBehaviour {

    [TagSelector,SerializeField] string tagReceptores;
    [SerializeField] string mensaje;

    public void EnviarMensaje()
    {
        UP_EnviarMensaje();
    }

    public void UP_EnviarMensaje()
    {
        GameObject[] objetosEtiquetados = GameObject.FindGameObjectsWithTag(tagReceptores);
        foreach(var o in objetosEtiquetados)
        {
            UP_EvMensaje[] receptores = o.GetComponents<UP_EvMensaje>();
            for (int i = 0; i < receptores.Length; i++)
            {   
                receptores[i].LanzarEventoMensaje(mensaje);
            }
        }
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(UP_FuncEnviarMensaje))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_FuncEnviarMensaje emisor = target as UP_FuncEnviarMensaje;

            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("tagReceptores"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("mensaje"));
            
            serializedObject.ApplyModifiedProperties();
        }
    }

#endif

}
