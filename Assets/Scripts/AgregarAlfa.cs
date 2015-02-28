using UnityEngine;
using System.Collections;

public class AgregarAlfa : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		ApplicationModel.alfas += 1;
		ApplicationModel.puntaje += ApplicationModel.constAgregar;

		ApplicationModel.ActualizarContadores ();

		/*
		// If the triggering gameobject is the player...
		if (other.gameObject == player) {
			// ... play the clip at the position of the key...
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			playerInventory.hasKey =true;
			Destroy(gameObject);
		}
		*/
	}
}
