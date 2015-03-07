using UnityEngine;
using System.Collections;

public class Salida : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Muerte, destruccion, cumbia!");
		if (col.name == "frasco") {
			Destroy(col.transform.parent.gameObject);
		}
	}

}
