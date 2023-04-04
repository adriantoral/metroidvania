using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UP_MovRotarHaciaObjeto : MonoBehaviour {

    public enum OrientacionBase
    {
        Arriba,
        Derecha,
        Abajo,
        Izquierda        
    }

    [SerializeField] bool buscarObjetivo = false;
    [SerializeField] GameObject objetivo;
    [SerializeField] string nombreObjetivo;

    [SerializeField] OrientacionBase orientacionBase;
    float rotacionBase { get { return (int)orientacionBase * 90; } }

    void Start()
    {
        
        if(buscarObjetivo)
        {
            this.objetivo = GameObject.Find(nombreObjetivo);
        }
    }

    void Update () {
        Vector3 direccion = objetivo.transform.position - this.transform.position;
        float angulo = Mathf.Atan2(-direccion.x, direccion.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotacionBase + angulo, Vector3.forward);
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(UP_MovRotarHaciaObjeto))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_MovRotarHaciaObjeto rotarHacia = target as UP_MovRotarHaciaObjeto;

            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("buscarObjetivo"));
            if (rotarHacia.buscarObjetivo)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("nombreObjetivo"));                
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("objetivo"));                
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("orientacionBase"));            

            serializedObject.ApplyModifiedProperties();
        }
    }

#endif
}
