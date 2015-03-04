using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void FixedUpdate(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, Gamemaster.instance.sensorDistance);
		if (hit.collider != null &&  hit.collider.name == "Envase(Clone)" && !Gamemaster.instance.correa.GetComponent<Correa> ().busy ) {
			if (!Gamemaster.instance.correa.GetComponent<Correa> ().stopped){
				Gamemaster.instance.correa.GetComponent<Correa> ().Stop ();
				Gamemaster.instance.SpawnEmbWrap ();
			}
		}
	}
}
