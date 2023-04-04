using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UP_FuncInstanciacion : MonoBehaviour {
   
    public enum TipoArea { Rectangulo, Circulo, Puntos }

    [SerializeField] bool aleatorizar = false;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject[] prefabs;

    [SerializeField] TipoArea tipoArea;
    [SerializeField] Vector2 areaRectangulo; // TODO: En curso 2019/20 cambiar a Size
    [SerializeField] float radioCirculo = 1;
    [SerializeField] bool enLimitesCirculo;
    [SerializeField] string tagPuntos;
    [SerializeField] bool pasarPorTodos = false;

    [SerializeField] bool emparentarAGenerador = false;

    [SerializeField] bool comprobarColisiones = false;
    [SerializeField] float radioComprobacion = 1;
    [SerializeField] LayerMask capaComprobacion;


    GameObject[] puntosTodos;
    List<GameObject> puntosProximoSpawn;

    public void Start()
    {        
        if(tipoArea == TipoArea.Puntos)
        {
            puntosTodos = GameObject.FindGameObjectsWithTag(tagPuntos);
            puntosProximoSpawn = new List<GameObject>(puntosTodos);
        }
    }

    public void UP_InstanciarObjeto()
    {
        Transform padre = emparentarAGenerador ? this.transform : null;        
        GameObject prefabElegido = ElegirPrefab();
        if(prefabElegido != null)
        {
            Vector2 posicionAleatoria;
            if(comprobarColisiones) { posicionAleatoria = PosicionAleatoriaSinColisiones(); }
            else { posicionAleatoria = PosicionAleatoria(); }
            
            GameObject newGO = Instantiate(prefabElegido, posicionAleatoria, this.transform.rotation, padre);
            AplicarInversionEscalaGlobal(newGO);
        }
    }

    void AplicarInversionEscalaGlobal(GameObject newGO)
    {
        if(this.transform.lossyScale.x < 0)
        {
            Vector3 newGOScale = newGO.transform.localScale;
            newGOScale.x = -Mathf.Abs(newGOScale.x);
            newGO.transform.localScale = newGOScale;
        }
    }

    private Vector2 PosicionAleatoriaSinColisiones()
    {
        int intentos = 10;
        bool colision = true;
        Vector3 posicionAleatoria;
        do
        {
            intentos -= 1;
            posicionAleatoria = PosicionAleatoria();
            colision = Physics2D.OverlapCircle(posicionAleatoria, radioComprobacion);
        }
        while (colision && intentos > 0);        
        return posicionAleatoria;
    }

    private Vector2 PosicionAleatoria()
    {
        Vector3 posicionAleatoria = this.transform.position;
        if (tipoArea == TipoArea.Rectangulo)
        {
            posicionAleatoria = PosicionAleatoriaEnRectangulo();
        }
        else if (tipoArea == TipoArea.Circulo)
        {
            posicionAleatoria = PosicionAleatoriaEnCirculo();
        }
        else if(tipoArea == TipoArea.Puntos)
        {
            posicionAleatoria = PosicionAleatoriaEnPuntos();
        }
        return posicionAleatoria;
    }

    private Vector2 PosicionAleatoriaEnCirculo()
    {
        Vector2 posicionInicial = this.transform.position;
        Vector2 distanciaAleatoria = Random.insideUnitCircle;
        if (enLimitesCirculo) { distanciaAleatoria.Normalize(); }
        distanciaAleatoria *= radioCirculo;

        posicionInicial += distanciaAleatoria;
        return posicionInicial;
    }

    private Vector2 PosicionAleatoriaEnRectangulo()
    {
        Vector2 posicionInicial = this.transform.position;
        Vector2 distanciaAleatoria = new Vector2(
                        x: Random.Range(-areaRectangulo.x / 2, areaRectangulo.x / 2),
                        y: Random.Range(-areaRectangulo.y / 2, areaRectangulo.y / 2));
        posicionInicial += distanciaAleatoria;
        return posicionInicial;
    }

    private Vector2 PosicionAleatoriaEnPuntos()
    {
        Vector3 posicion = this.transform.position;

        if(puntosProximoSpawn != null && puntosProximoSpawn.Count > 0)
        {
            int indiceAleatorio = Random.Range(0, puntosProximoSpawn.Count);
            posicion = puntosProximoSpawn[indiceAleatorio].transform.position;
            if(pasarPorTodos)
            {
                puntosProximoSpawn.RemoveAt(indiceAleatorio);
                if (puntosProximoSpawn.Count == 0) { puntosProximoSpawn.AddRange(puntosTodos); }
            }
        }

        return posicion;        
    }

    private GameObject ElegirPrefab()
    {
        GameObject prefabElegido = prefab;

        if (aleatorizar && prefabs != null && prefabs.Length > 0)
        {
            int nAleatorio = Random.Range(0, prefabs.Length);
            prefabElegido = prefabs[nAleatorio];
        }

        return prefabElegido;
    }

    void OnDrawGizmos()
    {
        if (tipoArea == TipoArea.Rectangulo)
        {
            Gizmos.color = Color.red;            
            Gizmos.DrawWireCube(
                center: this.transform.position, 
                size: areaRectangulo
            );
        }
        else if (tipoArea == TipoArea.Circulo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                center: this.transform.position,
                radius: radioCirculo);            
        }
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(UP_FuncInstanciacion))]
    public class CustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UP_FuncInstanciacion generador = target as UP_FuncInstanciacion;

            serializedObject.Update();
                        
            EditorGUILayout.LabelField("Prefab", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("aleatorizar"));
            
            if(!generador.aleatorizar) { EditorGUILayout.PropertyField(serializedObject.FindProperty("prefab")); }
            else { EditorGUILayout.PropertyField(serializedObject.FindProperty("prefabs")); }

            
            EditorGUILayout.LabelField("Área", EditorStyles.boldLabel);

            TipoArea tipoAreaPrevia = generador.tipoArea;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tipoArea"));
            
            if (generador.tipoArea != tipoAreaPrevia) { SceneView.RepaintAll(); }
            if (generador.tipoArea == TipoArea.Rectangulo)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("areaRectangulo"));
            }
            else if(generador.tipoArea == TipoArea.Circulo)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("radioCirculo"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("enLimitesCirculo"));                
            }
            else if(generador.tipoArea == TipoArea.Puntos)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("tagPuntos"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("pasarPorTodos"));                
            }

            EditorGUILayout.LabelField("Colisiones", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("comprobarColisiones"));            
            if(generador.comprobarColisiones)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("radioComprobacion"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("capaComprobacion"));
            }

            EditorGUILayout.LabelField("Emparentamiento", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("emparentarAGenerador"));

            serializedObject.ApplyModifiedProperties();
        }

    }

    

#endif
}
