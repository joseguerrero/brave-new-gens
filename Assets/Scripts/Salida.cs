using UnityEngine;
using System.Collections;

public class Salida : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Muerte, destruccion, cumbia!");
		Destroy (col.gameObject);
		
		if (col.name == "cuerpo") {
			Destroy(col.transform.parent.gameObject);
		}

		//Destroy (Gamemaster.instance.actualEmbryo);
		//Destroy (Gamemaster.instance.actualFlask);
		//Gamemaster.instance.correa.GetComponent<Correa> ().busy = false;

		Gamemaster.instance.headHit = false;
		Gamemaster.instance.bodyHit = false;
		//Gamemaster.instance.playerControl = false;
	}

}
