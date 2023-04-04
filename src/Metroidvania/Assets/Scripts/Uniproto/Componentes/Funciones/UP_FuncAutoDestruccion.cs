using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_FuncAutoDestruccion : MonoBehaviour {

    [SerializeField] GameObject prefabParticulas;

	public void UP_AutoDestruccion()
    {
        Destroy(this.gameObject);
        if(prefabParticulas)
        {
            Instantiate(prefabParticulas, this.transform.position, Quaternion.identity);
        }
    }

}
