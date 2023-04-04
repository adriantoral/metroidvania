using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_MovCursor : MonoBehaviour {

    [SerializeField] float distanciaCamara = 10;
    Camera camara;

    void Awake()
    {
        camara = Camera.main;
    }

    void Update () {
        Vector3 posRaton = Input.mousePosition;
        posRaton.z = distanciaCamara;
        this.transform.position = camara.ScreenToWorldPoint(posRaton);
	}
}
