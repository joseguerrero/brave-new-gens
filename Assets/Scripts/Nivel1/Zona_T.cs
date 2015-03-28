using UnityEngine;
using System.Collections;

public class Zona_T : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.name == "Frasco") {
			Gamemaster.instance.SpawnSubject ();
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		
	}

}
