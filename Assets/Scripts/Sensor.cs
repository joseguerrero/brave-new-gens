using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Envase(Clone)") {
			if (!Gamemaster.instance.correa.GetComponent<Correa> ().stopped){
				Gamemaster.instance.correa.GetComponent<Correa> ().Stop ();
				Gamemaster.instance.SpawnEmbWrap ();
			}
		}
	}
}
