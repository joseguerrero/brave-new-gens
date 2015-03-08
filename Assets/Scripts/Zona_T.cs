using UnityEngine;
using System.Collections;

public class Zona_T : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Gamemaster.instance.SpawnSubject ();
		//Gamemaster.instance.correa.GetComponent<Correa> ().actualSpeed -= 50;
	}
	
	void OnTriggerExit2D(Collider2D col){
		//Gamemaster.instance.correa.GetComponent<Correa> ().actualSpeed = Gamemaster.instance.correa.GetComponent<Correa> ().speed;
		//Gamemaster.instance.SpawnSubject ();
	}

}
